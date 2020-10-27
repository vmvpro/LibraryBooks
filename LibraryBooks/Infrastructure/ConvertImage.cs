using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibraryBooksClient.Infrastructure
{
	public class ConvertImage
	{
		/// <summary>
		/// Возвращает массив-байт (Получает: объект BitmapEncoder и объект ImageSource)
		/// </summary>
		/// <param name="encoder">Кодирует коллекцию объектов System.Windows.Media.Imaging.BitmapFrame в поток изображения.</param>
		/// <param name="imageSource"></param>
		/// <returns></returns>
		public static byte[] ImageToBytes(BitmapEncoder encoder, ImageSource imageSource)
		{
			byte[] bytes = null;
			var bitmapSource = imageSource as BitmapSource;

			if (bitmapSource != null)
			{
				encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

				using (var stream = new MemoryStream())
				{
					encoder.Save(stream);
					bytes = stream.ToArray();
				}
			}

			return bytes;
		}

		/// <summary>
		/// Возвращает массив-байт (Получает объект BitmapSource)
		/// </summary>
		/// <param name="image"></param>
		/// <returns></returns>
		public static byte[] ImageToBytes(BitmapSource image)
		{
			byte[] data;
			BitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}
			return data;
		}

		/// <summary>
		/// Возвращает массив-байт (Получает объект ImageSource)
		/// </summary>
		/// <param name="imageSource">Объект ImageSource</param>
		/// <returns></returns>
		public static byte[] ImageToBytes(ImageSource imageSource)
		{
			var image = imageSource as BitmapSource;
			byte[] data;
			BitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}
			return data;
		}

		/// <summary>
		/// Возвращает массив-байт (Получает объект URI)
		/// </summary>
		/// <param name="uri">URI объект</param>
		/// <returns></returns>
		public static byte[] ImageToBytes(Uri uri)
		{
			var image = new BitmapImage(uri);
			byte[] data;
			BitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}
			return data;
		}

		/// <summary>
		/// Возвращает массив-байт (Получает объект путь к файлу)
		/// </summary>
		/// <param name="filepath">Путь к файлу картинки в файловой системы</param>
		/// <returns></returns>
		public static byte[] ImageToBytes(string filepath)
		{
			var image = new BitmapImage(new Uri(filepath));
			byte[] data;
			BitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(image));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				data = ms.ToArray();
			}
			return data;
		}

		/// <summary>
		/// Возвращает объект BitmapImage (Получает массив byte[])
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static BitmapImage BytesToBitmapImage(Byte[] bytes)
		{
			var stream = new MemoryStream(bytes);
			stream.Seek(0, SeekOrigin.Begin);
			var image = new BitmapImage();
			image.BeginInit();
			image.StreamSource = stream;
			image.EndInit();
			return image;
		}

		/// <summary>
		/// Возвращает объект ImageSource (Получает массив byte[])
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static ImageSource BytesToImageSource(Byte[] bytes)
		{
			BitmapImage image = new BitmapImage();
			MemoryStream stream = new MemoryStream(bytes);

			//stream.Seek(0, SeekOrigin.Begin);

			image.BeginInit();
			image.StreamSource = stream;
			image.EndInit();

			return image;
		}
	}
}
