const fs = require('fs');
const pdf = require('pdf-parse');
 
let dataBuffer = fs.readFileSync('./sample.pdf');
 
pdf(dataBuffer).then(function(data) {

    console.log(data.text); 
        
});
// 'use strict';

// const path = require('path');
// const fs = require('fs').promises;

// const libre = require('libreoffice-convert');
// libre.convertAsync = require('util').promisify(libre.convert);

// async function main() {
//     const ext = '.xls'
//     const inputPath = path.join(__dirname, '/sample.pdf');
//     const outputPath = path.join(__dirname, `/example${ext}`);

//     // Read file
//     const docxBuf = await fs.readFile(inputPath);

//     // Convert it to pdf format with undefined filter (see Libreoffice docs about filter)
//     let pdfBuf = await libre.convertAsync(docxBuf, ext, undefined);
    
//     // Here in done you have pdf file which you can save or transfer in another stream
//     await fs.writeFile(outputPath, pdfBuf);
// }

// main().catch(function (err) {
//     console.log(`Error converting file: ${err}`);
// });