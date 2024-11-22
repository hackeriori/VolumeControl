using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System.Runtime.InteropServices;

namespace VolumeControl
{
    public partial class Form1 : Form
    {
        // Import the user32.dll for registering and unregistering hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Hotkey identifiers
        private const int HOTKEY_ID_INCREASE = 1;
        private const int HOTKEY_ID_DECREASE = 2;

        // Modifier keys
        private const uint MOD_ALT = 0x0001;

        // Virtual key codes
        private const uint VK_OEM_PLUS = 0xBB; // '+'
        private const uint VK_OEM_MINUS = 0xBD; // '-'

        private MMDevice device;
        private MMDeviceEnumerator deviceEnumerator;
        private NotificationClient notificationClient;

        public Form1()
        {
            InitializeComponent();
            deviceEnumerator = new MMDeviceEnumerator();
            notificationClient = new NotificationClient(this);
            deviceEnumerator.RegisterEndpointNotificationCallback(notificationClient);
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.OnVolumeNotification += OnVolumeNotification;
            GetDeviceInfo();
            RegisterHotKeys();
        }

        public void GetDevice()
        {
            if (device != null)
            {
                device.AudioEndpointVolume.OnVolumeNotification -= OnVolumeNotification;
            }
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            device.AudioEndpointVolume.OnVolumeNotification += OnVolumeNotification;
        }

        private void RegisterHotKeys()
        {
            if (!RegisterHotKey(this.Handle, HOTKEY_ID_INCREASE, MOD_ALT, VK_OEM_PLUS))
            {
                MessageBox.Show("'Alt' + '+'热键注册失败", "警告");
            }
            if (!RegisterHotKey(this.Handle, HOTKEY_ID_DECREASE, MOD_ALT, VK_OEM_MINUS))
            {
                MessageBox.Show("'Alt' + '-'热键注册失败", "警告");
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Handle the hotkey events
            if (m.Msg == 0x0312) // WM_HOTKEY
            {
                switch (m.WParam.ToInt32())
                {
                    case HOTKEY_ID_INCREASE:
                        ChangeVolume(0.01f); // Increase volume by 1%
                        break;
                    case HOTKEY_ID_DECREASE:
                        ChangeVolume(-0.01f); // Decrease volume by 1%
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void ChangeVolume(float delta)
        {
            float currentVolume = device.AudioEndpointVolume.MasterVolumeLevelScalar;
            float newVolume = Math.Clamp(currentVolume + delta, 0.0f, 1.0f);
            device.AudioEndpointVolume.MasterVolumeLevelScalar = newVolume;
        }

        private void OnVolumeNotification(AudioVolumeNotificationData notificationData)
        {
            // 音量变化时更新显示
            this.Invoke(GetDeviceInfo);
        }

        public void GetDeviceInfo()
        {
            nameLabel.Text = device.FriendlyName;
            var currentVolume = device.AudioEndpointVolume.MasterVolumeLevelScalar;
            volumeLabel.Text = Math.Round(currentVolume * 100).ToString();
            muteCheck.Checked = device.AudioEndpointVolume.Mute;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID_INCREASE);
            UnregisterHotKey(this.Handle, HOTKEY_ID_DECREASE);
            device.AudioEndpointVolume.OnVolumeNotification -= OnVolumeNotification;
            deviceEnumerator.UnregisterEndpointNotificationCallback(notificationClient);
            base.OnFormClosing(e);
        }

        private void muteCheck_CheckedChanged(object sender, EventArgs e)
        {
            device.AudioEndpointVolume.Mute = muteCheck.Checked;
        }
    }

    public class NotificationClient : IMMNotificationClient
    {
        private readonly Form1 form;

        public NotificationClient(Form1 form)
        {
            this.form = form;
        }

        public void OnDefaultDeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
        {
            this.form.Invoke(new Action(() =>
            {
                this.form.GetDeviceInfo();
                this.form.GetDevice();
            }));
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
        }

        public void OnDeviceRemoved(string deviceId)
        {
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
        }
    }
}
