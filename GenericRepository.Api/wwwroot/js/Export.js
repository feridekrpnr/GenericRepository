function Export2Doc(element, report, reportName, cssUrl, margins) {

    var preHtml = "<html lang='en' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='http://www.w3.org/TR/REC-html40'><head><meta charset='utf-8'><title>Döküman Çıktısı</title><link href='" + cssUrl + "' rel='stylesheet'/>"

    if (margins == null || margins == undefined)
        margins = '0.2cm 0.8cm 0cm 0.2cm';
    var styles = '<style>\n' +
        '@page\n' +
        '{\n' +
        '    size:21cm 29.7cmt;  /* A4 */\n' +
        '    margin:' + margins + '; \n' +
        '    mso-page-orientation: portrait;  \n' +
        '   \n' +
        '}\n' +
        '@page a4 { }\n' +
        'div.a4 { page:a4; }\n' +
        'p.MsoHeader, p.MsoFooter { border: 1px solid black; }\n' +
        '</style>\n';

    var closeHead = "</head > <body>";
    var postHtml = "</body></html>";
    var el = document.getElementById(element);
    debugger;
    var html = preHtml + styles + closeHead + el.outerHTML + postHtml;

    var blob = new Blob(['\ufeff', html], {
        type: 'application/msword'
    });

    var url = 'data:application/vnd.ms-word;charset=utf-8,' + encodeURIComponent(html);

    // Specify file name
    var filename = reportName + '.doc';

    // Create download link element
    var downloadLink = document.createElement("a");

    document.body.appendChild(downloadLink);

    if (navigator.msSaveOrOpenBlob) {
        navigator.msSaveOrOpenBlob(blob, filename);
    } else {
        // Create a link to the file
        downloadLink.href = url;

        // Setting the file name
        downloadLink.download = filename;

        //triggering the function
        downloadLink.click();
    }

    document.body.removeChild(downloadLink);
}
const btn1 = document.querySelector("#btn1");
function yazdir(alanID) {
    //yazdırılacak nesneyi seçme
    let yazilacakAlan = document.querySelector(alanID);
    var originalContents = document.body.innerHTML;
    document.body.innerHTML = yazilacakAlan.innerHTML;
    print();
    document.body.innerHTML = originalContents;
    location.reload();

}

//buton tıklama olayları
//write.onclick = function () {
//    yazdir("#a4");
//}
