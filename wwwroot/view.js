
function updateView() 
{
    document.getElementById("app").innerHTML = mainPageHTML();
}

function mainPageHTML() 
{
    return /*HTML*/ `
        <h2>Certifications</h2>

        <input placeholder="Type" oninput="model.inputs.type = this.value">
        <input placeholder="Number" oninput="model.inputs.number = this.value">
        <input placeholder="Notified body" oninput="model.inputs.notifiedbody = this.value">
        <input type="date" placeholder="YYYY-MM-DD" oninput="model.inputs.issueDate = this.value">
        <input type="date" placeholder="YYYY-MM-DD" oninput="model.inputs.expiryDate = this.value">
        <br>
        <input id="fileInput" type="file" placeholder="Upload certification">
        <button onclick="SubmitAll()">Submit</button>

        <br>
        <h3>Search certifications:</h3>
        <input placeholder="Certification type" oninput="model.searchByType = this.value">
        <button onclick="SearchByType()">Search by type</button>
        <input placeholder="Certification number" oninput="model.searchByNumber = this.value">
        <button onclick="SearchByNumber()">Search by number</button>
        <br>
        ${(model.searchByType == "" && model.searchByNumber == "") ? renderFullCertList() : renderSearchResults()}
    `;
}


function renderFullCertList() 
{
    return model.fullCertificationList.map(cert => CertListHtml(cert)).join("");
}


function renderSearchResults() 
{
    return model.searchResults.map(cert => CertListHtml(cert)).join("");
}

function CertListHtml(cert) 
{
    return `
        <div>
            ${cert.type} - ${cert.number} - ${cert.notifiedBody} - ${cert.issueDate} - ${cert.expiryDate}
            <button onclick="downloadCert('${cert.number}')">Download</button>
        </div>
    `;
}
