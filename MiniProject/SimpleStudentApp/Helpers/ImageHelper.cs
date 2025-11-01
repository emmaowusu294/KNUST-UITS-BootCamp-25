namespace SimpleStudentApp.Helpers
{
    public static class ImageHelper
    {
        // Change the method signature to accept the mime type
        public static string GetImageSrc(byte[] image, string mimeType)
        {
            if (image == null || string.IsNullOrEmpty(mimeType))
            {
                return null;
            }

            var base64Image = Convert.ToBase64String(image);

            // Use the 'mimeType' variable instead of hard-coding "image/jpeg"
            return string.Format("data:{0};base64,{1}", mimeType, base64Image);
        }
    }
}