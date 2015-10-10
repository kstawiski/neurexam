using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Media;
using Helpers = Badanie_Neurologiczne.HelperMethods;
using Res = Badanie_Neurologiczne.Properties.Resources;

namespace Badanie_Neurologiczne
{
    public partial class NotatkiGlosowe : Form
    {
        public string katalogpacjenta;
        private SndRec _sndrec = SndRec.Instance;
        private SndPlay _sndplay = SndPlay.Instance;
        private bool _recording, _playing, _paused;
        private System.Threading.Timer _timer;
        private DateTime _startDate;
        
        private void StartTimer()
        {
            _timer.Change(0, 500);
        }
        private void StopTimer()
        {
            _timer.Change(Timeout.Infinite, 500);
        }
        
        public NotatkiGlosowe()
        {
            InitializeComponent();

            
        }

        private void NotatkiGlosowe_Load(object sender, EventArgs e)
        {
            this.saveFileDialog.Title = Application.ProductName + " - Przekopiuj";
            _timer = new System.Threading.Timer(TimerProc);
            SetButtonState();
            timer1.Enabled = false;
            listBox1.Items.Clear();
            string[] fileEntries = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "\\notatki i nagrania");
            foreach (string fileName in fileEntries)
            {
                // do something with fileName
                listBox1.Items.Add(Path.GetFileName(fileName));
            }
            
            this.Cursor = Cursors.WaitCursor;
            //this.recordingsListView.BeginUpdate();

            string[] arr = Helpers.GetRecordings(katalogpacjenta );
            foreach (string str in arr)
                AddRecording(str);

            //this.recordingsListView.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void recordToolStripButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Helpers.GetNewRecording("", katalogpacjenta));
            if (_recording)
            {
                try
                {
                    string path;

                    path = Helpers.GetNewRecording(Helpers.GetTimeStr(_sndrec.Length).Replace(":", string.Empty), katalogpacjenta);

                    _sndrec.Stop();

                    StopTimer();
                    _recording = false;
                    SetButtonState();

                    _sndrec.Save(path);

                    
                    //AddRecording(path);

                    _sndrec.Close();
                    string file = Path.GetFileName(path);
                    File.Move(path, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania\\" + file);
                    listBox1.Items.Clear();
                    string[] fileEntries = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania");
                    foreach (string fileName in fileEntries)
                    {
                        // do something with fileName
                        listBox1.Items.Add(Path.GetFileName(fileName));
                    }
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else
            {
                try
                {
                    if (!_sndrec.IsInitialized)
                        _sndrec.Initialize();

                    _sndrec.Start();
                    _startDate = DateTime.Now;
                    StartTimer();

                    _recording = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
        }

        private void recordingsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonState();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (Helpers.AskMsgBox(this, Res.MsgBox_Delete) == DialogResult.Yes)
            {
                ////ListViewItem itm = this.recordingsListView.SelectedItems[0];
                ////string path = itm.Tag.ToString();

                //try
                //{
                //    File.Delete(path);
                //    itm.Remove();
                //}
                //catch (FileNotFoundException) { itm.Remove(); }
                //catch (IOException ex)
                //{
                //    Helpers.ErrMsgBox(this, ex.Message);
                //}
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    //File.Copy(this.recordingsListView.SelectedItems[0].Tag.ToString(), this.saveFileDialog.FileName);
                }
                catch (IOException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
        }

        private void playToolStripButton_Click(object sender, EventArgs e)
        {
            if (_playing && _paused)    // Resume
            {
                try
                {
                    _sndplay.Resume();

                    _startDate = DateTime.Now;
                    StartTimer();
                    _paused = false;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else if (_playing)      // Pause
            {
                try
                {
                    _sndplay.Pause();

                    StopTimer();
                    _paused = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }
            }
            else                    // Play
            {
                try
                {
                    //string filename = this.recordingsListView.SelectedItems[0].Tag.ToString();

                    //if (!_sndplay.IsInitialized)
                    //    _sndplay.Initialize(filename, this.Handle);

                    _sndplay.Start();
                    _startDate = DateTime.Now;
                    StartTimer();

                    _playing = true;
                    SetButtonState();
                }
                catch (SndException ex)
                {
                    Helpers.ErrMsgBox(this, ex.Message);
                }

            }
        }

        private void SetButtonState()
        {
            //bool bSelected = this.recordingsListView.SelectedItems.Count > 0;

            this.recordToolStripButton.Text = _recording ? "Zakończ nagrywanie adnotacji głosowej." : "Rozpocznij nagrywanie adnotacji głosowej.";
            this.recordToolStripButton.Image = _recording ? Res.PauseRecorderHS : Res.RecordHS;
            this.recordToolStripButton.Enabled = !_playing;

            //this.recordingsListView.Enabled = !_recording && !_playing;

            //this.playToolStripButton.Enabled = !_recording && bSelected;
            //this.stopToolStripButton.Enabled = _playing;
            //this.saveToolStripButton.Enabled = !_recording && bSelected && !_playing;
            //this.deleteToolStripButton.Enabled = !_recording && bSelected && !_playing;

            //if ((_playing && _paused) || (!_recording && !_playing))
            //{
            //    this.playToolStripButton.Text = "Odtwarzaj.";
            //    this.playToolStripButton.Image = Res.PlayHS;
            //}
            //else
            //{
            //    this.playToolStripButton.Text = "Pauza.";
            //    this.playToolStripButton.Image = Res.PauseHS;
            //}
        }

        private void TimerProc(object obj)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(SetTime));
            else
                SetTime();
        }

        private void SetTime()
        {
            if (_recording)
            {
                this.lengthToolStripLabel.Text = Helpers.GetTimeStr(_sndrec.Length);
            }
            else
            {
                string len = Helpers.GetTimeStr(_sndplay.Length);
                string pos = Helpers.GetTimeStr(_sndplay.Position);

                //this.locationToolStripLabel.Text = String.Format(CultureInfo.InvariantCulture, "{0}/{1}", pos, len);

                if (_sndplay.Position == _sndplay.Length)
                {
                    try
                    {
                        StopTimer();
                        _playing = _paused = false;
                        SetButtonState();
                        _sndplay.Close();
                    }
                    catch (SndException ex)
                    {
                        Helpers.ErrMsgBox(this, ex.Message);
                    }
                }
            }
        }

        private void AddRecording(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string[] vals = name.Split('-');
            DateTime date = new DateTime(
                int.Parse(vals[0].Substring(4, 4), CultureInfo.InvariantCulture),
                int.Parse(vals[0].Substring(0, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[0].Substring(2, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(0, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(2, 2), CultureInfo.InvariantCulture),
                int.Parse(vals[1].Substring(4, 2), CultureInfo.InvariantCulture));
            //string length = string.Format(CultureInfo.InvariantCulture, "{0:D2}:{1:D2}:{2:D2}",
            //    vals[2].Substring(0, 2),
            //    vals[2].Substring(2, 2),
             //   vals[2].Substring(4, 2));

            ListViewItem itm = new ListViewItem(date.ToShortDateString() + " " + date.ToLongTimeString());
            //itm.SubItems.Add(length);
            itm.Tag = path;
            //this.recordingsListView.Items.Add(itm);
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _sndplay.Stop();

                StopTimer();
                _playing = _paused = false;
                SetButtonState();

                _sndplay.Close();
            }
            catch (SndException ex)
            {
                Helpers.ErrMsgBox(this, ex.Message);
            }
        }
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        bool n = false;
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (n == false)
            {
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendString("record recsound", "", 0, 0);
                n = true;
            }
            else {
                mciSendString(@"save recsound " + Helpers.GetNewRecording("", katalogpacjenta) + ".wav", "", 0, 0);
                mciSendString("close recsound ", "", 0, 0);
                //Helpers.GetNewRecording("", katalogpacjenta);
                n = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] fileEntries = Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania");
            foreach (string fileName in fileEntries)
            {
                // do something with fileName
                listBox1.Items.Add(Path.GetFileName(fileName));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stream str = Application.StartupPath + "\\" + katalogpacjenta + "notatki i nagrania" + listBox1.SelectedItem.ToString();
            if (listBox1.SelectedIndex != -1)
            {
                SoundPlayer simpleSound = new SoundPlayer(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania\\" + listBox1.SelectedItem.ToString());
                simpleSound.PlayLooping();
                button3.Enabled = true; button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                SoundPlayer simpleSound = new SoundPlayer(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania\\" + listBox1.SelectedItem.ToString());
                simpleSound.Stop(); button3.Enabled = false; button1.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) { button3.Enabled = false; button1.Enabled = true; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\Badanie Neurologiczne by Konrad Stawiski\\" + katalogpacjenta + "notatki i nagrania\\" + listBox1.SelectedItem.ToString());
        }
       



    }
}
