using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace player
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			this.dTimer.IsEnabled = false;
			this.dTimer.Tick += this.dispatcherTimer_Tick;
			this.volumeslider.Maximum = this.max_volumn;
			this.volumeslider.Value = this.max_volumn;
			this.ResizeMode = ResizeMode.NoResize;
		}
		private DispatcherTimer dTimer = new DispatcherTimer();
		private double max_volumn = 1.0;
		private void playButton_Click(object sender, RoutedEventArgs e)  //播放mp3文件
		{
			
			
			this.mediaelement1.Volume =this.max_volumn;
			
			if(this.mediaelement1.Source != null)
			{
				this.playMusic();
			}
			else
			{
				MessageBox.Show("还未选中文件");
				return;
			}


		}
		private void playMusic()    //播放mp3文件
		{
			this.mediaelement1.Play();
			
			this.dTimer.IsEnabled = true;
			this.dTimer.Interval = TimeSpan.FromSeconds(1);
			this.playButton.IsEnabled = false;
			//设定进度条最大值,根据文件时长
			this.playSlider.Maximum = this.calcuTotalSeconds(this.parseDuration(this.mediaelement1.NaturalDuration.TimeSpan.ToString()));
		}
		
		private void dispatcherTimer_Tick(object sender, EventArgs e)      //设置一个定时器 使得播放文件时进度条自动前进
		{
			//this.playSlider.Value = this.mediaelement1.Position.TotalSeconds; //slider滑动值随播放内容位置变化
			this.timelabel.Content = this.parseDuration(this.mediaelement1.Position.ToString());            //当前播放长度
			this.totaltimelabel.Content = this.parseDuration(this.mediaelement1.NaturalDuration.TimeSpan.ToString());       //总播放长度

			this.changeSliderValue();

		}

		


		private double slidervalue = -1;

		
		private void changeSliderValue()
		{


			this.slidervalue = this.playSlider.Value;
			this.playSlider.Value += 1;

		}
		private void parseSliderDrag()
		{
			this.mediaelement1.Position = TimeSpan.FromSeconds(this.playSlider.Value);
		}
		private string parseDuration(string input)
		{
			//将播放时间变为 00:00的格式
			string s1 = new StringBuilder(input).Remove(0, 3).ToString();
			string s2 = new StringBuilder(s1).ToString();
			if (s2.Length > 5)
			{
				s2 = s2.Remove(5, s2.Length - 5);
			}
			return s2;
		}
		private int calcuTotalSeconds(String input)
		{
			//计算 形如05：21的总秒数
			string minutes = new StringBuilder(input).Remove(2, 3).ToString();
			string seconds = new StringBuilder(input).Remove(0, 3).ToString();
			int mins = int.Parse(minutes);
			int secs = int.Parse(seconds);
			int ret = mins * 60 + secs;
			return ret;
		}

		private void pauseZanTingButton_Click(object sender, RoutedEventArgs e)
		{
			this.mediaelement1.Pause();
			this.dTimer.IsEnabled = false;
			this.playButton.IsEnabled = true;

			
		}

		private void stopTingZhiButton_Click(object sender, RoutedEventArgs e)
		{
			this.mediaelement1.Stop();
			this.dTimer.IsEnabled = false;
			this.playSlider.Value = 0;
			this.playButton.IsEnabled = true;
			
			
		}


		private void getFileInfo(Uri uri)
		{
			string path = uri.ToString();
			

			MP3Info info = MP3Helper.ReadMP3Info(path);
		
			this.currmusic = info;
			
		}
		public MP3Info? currmusic = null;
		private void chooseFileButton_Click(object sender, RoutedEventArgs e)
		{

			//添加文件至播放列表
			CommonOpenFileDialog open = new CommonOpenFileDialog();
			open.EnsureReadOnly = true;
			open.Filters.Add(new CommonFileDialogFilter("Mp3文件", "*.mp3"));
			//open.Filters.Add(new CommonFileDialogFilter("txt文件", "*.txt"));
			//open.Filters.Add(new CommonFileDialogFilter("Mp4文件", "*.mp4"));
			//open.Filters.Add(new CommonFileDialogFilter("Wmv文件", "*.wmv"));
			//open.Filters.Add(new CommonFileDialogFilter("Avi文件", "*.avi"));

			if (open.ShowDialog() == CommonFileDialogResult.Ok)
			{
				//指定媒体文件地址
				Uri uri = new Uri(open.FileName, UriKind.Relative);

				
				
				if (this.exists(uri.ToString()) == false)
				{
					//之前没添加过此路径
					int lastindex = uri.ToString().LastIndexOf(@"\");
					//musicname是将路径去掉，只留下名称
					string musicname = uri.ToString().Substring(lastindex + 1, uri.ToString().Length - lastindex - 1);
					
					this.music_path_name_dict[uri] = musicname;
					if (this.musiclist.Items.Count == 0)  //播放列表为空
					{
						this.mediaelement1.Source = uri;
						this.musiclist.SelectedItem = musicname;
					}
					this.musiclist.Items.Add(musicname);

				}
				else
				{
					//已存在路径
					MessageBox.Show("已存在此路径，无法加入");
					return;
				}
				

			}


			
		}
		private void extract_Front_Page(string path)
		{
			//提取封面
			byte[] res = MP3Helper.extractFrontPage(path);
			if(res != null)
			{
				//有封面
			}
			BitmapSource source =  MP3Helper.LoadImage(res);
			this.image.Source = source;
		}
		
		private void changeMusicSource(string musicname)
		{
			foreach(Uri key in this.music_path_name_dict.Keys)
			{
				if(this.music_path_name_dict[key].Equals(musicname))
				{
					this.mediaelement1.Source = key;
					this.musiclist.SelectedItem = musicname;
					this.getFileInfo(key);
					this.label1.Content = "现在播放:" + musicname;
					this.playSlider.Value= 0;

					this.mediaelement1.Pause();
					this.dTimer.IsEnabled = false;
					this.playButton.IsEnabled = true;
					this.extract_Front_Page(key.ToString());
				}
				
			}
		}


		private bool exists(string path)
		{
			//判断路径名是否已经存在
			
			Func<Uri, bool> func = (Uri uri) =>
			 {
				 if(path.Equals(uri.ToString()))
				 {
					 return true;
				 }
				 else
				 {
					 return false;
				 }
			 };
			IEnumerable<Uri> res =  this.music_path_name_dict.Keys.Where(func);
		
			if(res.Count() > 0)
			{
				return true;  //该路径已存在
			}
			else
			{
				return false;
			}
		}

		private Dictionary<Uri, string> music_path_name_dict = new Dictionary<Uri, string>();
		private void mediaelement1_MediaOpened(object sender, RoutedEventArgs e)
		{
			
		}

		private void mediaelement1_MediaFailed(object sender, ExceptionRoutedEventArgs e)
		{
			MessageBox.Show("加载失败");
		}

		private void deleteFileButton_Click(object sender, RoutedEventArgs e)
		{
			if(this.musiclist.SelectedItem == null)
			{
				MessageBox.Show("请选中要删除的项目");
				return;
			}

			//删除选中的那项

			Func<Uri, bool> func = (Uri uri) => 
			{
				if(this.music_path_name_dict[uri].Equals(this.musiclist.SelectedItem.ToString()))
				{
					return true;
				}
				else
				{
					return false;
				}
			};
			IEnumerable<Uri> reslist =  this.music_path_name_dict.Keys.Where(func);
			this.music_path_name_dict.Remove(reslist.First());
			this.musiclist.Items.Remove(this.musiclist.SelectedItem);
		}

		private void musiclist_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.changeMusicSource(this.musiclist.SelectedItem.ToString());
			}
			catch
			{
				try
				{
					this.changeMusicSource(this.musiclist.Items[0].ToString());
				}
				catch
				{
					this.mediaelement1.Source = null;	
					this.label1.Content = "还未选中播放文件" ;
					this.playSlider.Value = 0;
					this.mediaelement1.Stop();
					this.dTimer.IsEnabled = false;
					this.playButton.IsEnabled = false;
					this.image.Source = null;
				}
			}
			
			this.mediaelement1.Stop();
		}

		private void showfileinfoBtn_Click(object sender, RoutedEventArgs e)
		{
			if(this.currmusic == null)
			{
				MessageBox.Show("还未选中播放文件");
				return;
			}
			MessageBox.Show(this.currmusic.ToString());
		}

		private void playSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if(this.playSlider.Value-this.slidervalue == 1)
			{
				return;
			}
			this.mediaelement1.Position = TimeSpan.FromSeconds(this.playSlider.Value);
		}

		private void volumeslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.mediaelement1.Volume = this.volumeslider.Value;
		}
	}
}
