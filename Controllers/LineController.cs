using QRCoder;
using Microsoft.AspNetCore.Mvc;

namespace qrc.Controllers;
    [Route("[controller]")]
    public class LineController : ControllerBase {
        [HttpGet("{queue}")]
        public IActionResult line(int queue) {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://bethenext.one/queue/" + queue, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return File(qrCodeAsPngByteArr, "image/jpg");
        }
        [HttpGet("download/{queue}")]
        public IActionResult download(int queue) {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://bethenext.one/queue/" + queue, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return File(qrCodeAsPngByteArr, "image/jpg", "qr_code_bethenext_one");
        }
        [HttpGet("invite")]
        public IActionResult invite() {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://bethenext.one", QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return File(qrCodeAsPngByteArr, "image/jpg");
        }
        [HttpGet("dangerous/{dangerous}")]
        public IActionResult dangerous(string dangerous) {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(dangerous, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);
            return File(qrCodeAsPngByteArr, "image/jpg");
        }
    }

