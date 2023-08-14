using ImageMagick;

namespace ICA.Services
{
    public class ImageCompresser
    {
        public static async Task<bool> BusImageCompresser(string path, string filename)
        {
            var ImageUrl = Path.Combine(path, filename);
            using (var image = new MagickImage(ImageUrl))
            {
                try
                {

                    var size = new MagickGeometry(500, 500);
                    //// This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    size.IgnoreAspectRatio = false;

                    image.Resize(size);
                    image.Quality = 75;
                    //   Save the result
                    await image.WriteAsync(path + "\\Resized" + filename);
                    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
