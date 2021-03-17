package com.xy.lastcargame;
import android.Manifest;
import android.app.AlertDialog;
import android.bluetooth.BluetoothAdapter;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.location.LocationManager;
import android.os.Build;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.provider.Settings;
import android.util.Log;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import java.util.ArrayList;
import java.util.List;

import devin.com.linkmanager.LinkManager;
import devin.com.linkmanager.bean.Angle;
import devin.com.linkmanager.bean.DataType;
import devin.com.linkmanager.bean.Power;

import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;

public class MainActivity extends UnityPlayerActivity {
    Handler handler1 = new Handler(){
        @Override
        public void handleMessage(Message msg) {
            super.handleMessage(msg);
            switch (msg.what){
                case DataType.CODE_UP_SEND_START:
                    SendToUnityStatus(msg.what+"|"+"开始发送升级包");
                    break;
                case DataType.CODE_UP_SEND_ING:
                    SendToUnityStatus(msg.what+"|"+"升级包发送" + msg.arg1 + "%...");
                    break;
                case DataType.CODE_UP_SEND_END:
                    SendToUnityStatus(msg.what+"|"+"升级包发完毕");
                    break;
                case DataType.CODE_UP_SUCCEED:
                    SendToUnityStatus(msg.what+"|"+"升级成功");
                    break;
                case DataType.CODE_CONNECT_SUCCEED:
                    SendToUnityStatus(msg.what+"|"+"连接成功");
                    break;
                case DataType.CODE_CONNECT_FAIL:
                    SendToUnityStatus(msg.what+"|"+"连接失败");
                    break;
                case DataType.CODE_POOR_SIGNAL:
                    SendToUnityStatus(msg.what+"|"+ msg.arg1);
                    break;
                case DataType.CODE_ATTENTION:
                    SendToUnityStatus(msg.what+"|" +  msg.arg1);
                    break;
               /* case DataType.CODE_MEDITATION
                    SendToUnityStatus(msg.what+"|"+  msg.arg1);
                    break;*/
                case DataType.CODE_RAW:
                    /*if(tv1.getText().length() > 5000){
                        tv1.setText("");
                    }
                    stringTv1 = tv1.getText()+ " raw：" +  msg.arg1;
                    tv1.setText(stringTv1);
                    */
//                    Parser p = new Parser();
//                    byte result = (byte)(msg.arg1&0xFF);
//                    int w = p.parseByte(result);
                    SendToUnityStatus(msg.what+"|"+ msg.arg1);
                    break;
                case DataType.CODE_EEGPOWER:
                    Power power = (Power)msg.obj;
                    String stringTv1 =  "delta:" + power.delta + "   theta:" + power.theta + "   lowAlpha:" + power.lowAlpha
                            + "   highAlpha:" + power.highAlpha + "   lowBete:" + power.lowBeta
                            + "   highBete:" + power.highBeta + "   lowGamma:" + power.lowGamma + "   middleGamma:" + power.middleGamma
                            + "   fancyDegree:" + power.fancyDegree + "   electric:" + power.electric + "   version:" + power.version;
                    SendToUnityStatus(msg.what+"|"+"eeg: "+stringTv1);
                    break;
                case DataType.CODE_ANGLE:
                    Angle angle = (Angle)msg.obj;
                    SendToUnityStatus(msg.what+"|" + angle.yaw + "|" +  angle.bow +"|" +  angle.across);
                    break;
            }
        }
    };


    private void SendToUnityStatus(String msg)
    {
        UnityPlayer.UnitySendMessage("XYCarProxy","SensorInfo",msg);
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.e("xycar", "oncreate");
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_main);
        //initView();

        verifyStoragePermissions();
        checkPermissions();

        LinkManager.getInstance().init(getApplication());

    }
    public void initView(){
        Log.e("xycar", "initView");
        LinkManager.getInstance().setConnectiDeviceFirst(handler1);
    }



    private static final int REQUEST_EXTERNAL_STORAGE = 3;
    private static String[] PERMISSIONS_STORAGE = {
            "android.permission.READ_EXTERNAL_STORAGE",
            "android.permission.WRITE_EXTERNAL_STORAGE" };
    public void verifyStoragePermissions() {

        try {
            //检测是否有读写的权限
            int permissionRead = ActivityCompat.checkSelfPermission(this,
                    "android.permission.WRITE_EXTERNAL_STORAGE");
            int permissionWrite = ActivityCompat.checkSelfPermission(this,
                    "android.permission.WRITE_EXTERNAL_STORAGE");
            if (permissionRead != PackageManager.PERMISSION_GRANTED &&
                    permissionWrite != PackageManager.PERMISSION_GRANTED) {
                // 没有写的权限，去申请读写的权限，会弹出对话框
                ActivityCompat.requestPermissions(this, PERMISSIONS_STORAGE,REQUEST_EXTERNAL_STORAGE);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static final int REQUEST_CODE_OPEN_GPS = 1;
    private static final int REQUEST_CODE_PERMISSION_LOCATION = 2;
    private void checkPermissions() {
        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        if (!bluetoothAdapter.isEnabled()) {
            Toast.makeText(this, "请打开蓝牙", Toast.LENGTH_LONG).show();
            return;
        }

        String[] permissions = {Manifest.permission.ACCESS_FINE_LOCATION};
        List<String> permissionDeniedList = new ArrayList<>();
        for (String permission : permissions) {
            int permissionCheck = ContextCompat.checkSelfPermission(this, permission);
            if (permissionCheck == PackageManager.PERMISSION_GRANTED) {
                onPermissionGranted(permission);
            } else {
                permissionDeniedList.add(permission);
            }
        }
        if (!permissionDeniedList.isEmpty()) {
            String[] deniedPermissions = permissionDeniedList.toArray(new String[permissionDeniedList.size()]);
            ActivityCompat.requestPermissions(this, deniedPermissions, REQUEST_CODE_PERMISSION_LOCATION);
        }
    }
    private void onPermissionGranted(String permission) {
        switch (permission) {
            case Manifest.permission.ACCESS_FINE_LOCATION:
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M && !checkGPSIsOpen()) {
                    new AlertDialog.Builder(this)
                            .setTitle("提示")
                            .setMessage("手机扫描需要打开定位功能")
                            .setNegativeButton("取消",
                                    new DialogInterface.OnClickListener() {
                                        @Override
                                        public void onClick(DialogInterface dialog, int which) {
                                            finish();
                                        }
                                    })
                            .setPositiveButton("前往设置",
                                    new DialogInterface.OnClickListener() {
                                        @Override
                                        public void onClick(DialogInterface dialog, int which) {
                                            Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                                            startActivityForResult(intent, REQUEST_CODE_OPEN_GPS);
                                        }
                                    })

                            .setCancelable(false)
                            .show();
                } else {

                }
                break;
        }
    }
    private boolean checkGPSIsOpen() {
        LocationManager locationManager = (LocationManager) this.getSystemService(Context.LOCATION_SERVICE);
        if (locationManager == null)
            return false;
        return locationManager.isProviderEnabled(android.location.LocationManager.GPS_PROVIDER);
    }

    @Override
    protected void onDestroy() {
        LinkManager.getInstance().close();
        super.onDestroy();
    }
}
