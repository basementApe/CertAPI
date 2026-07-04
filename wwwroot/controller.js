async function GetData() 
{
    const response = await axios.get("/api/completelist");
    model.fullCertificateList = response.data;
}

// async function PostData(cert) 
// {
//     const msg = await axios.post("/api/cert", cert);
// }

async function SearchByType() 
{
    const response = await axios.get("/api/searchtype", { params: { type: model.searchByType } });
    model.searchResults = response.data;
    updateView();
}

async function SearchByNumber() 
{
    const response = await axios.get("/api/searchnumber", { params: { number: model.searchByNumber } });
    model.searchResults = response.data;
    updateView();
}

function ClearSearches() 
{
    model.searchByType = "";
    model.searchByNumber = "";
}

async function SubmitAll() 
{
    if (InvalidInput()) 
    {
        alert("All fields must be filled in.");
        return;
    }

    const file = document.getElementById("fileInput").files[0];

    if (!file) 
    {
        alert("Please select a certificate file.");
        return;
    }

    const formData = new FormData();

    formData.append("type", model.inputs.type);
    formData.append("number", model.inputs.number);
    formData.append("notifiedBody", model.inputs.notifiedbody);
    formData.append("issueDate", model.inputs.issueDate);
    formData.append("expiryDate", model.inputs.expiryDate);

    formData.append("file", file);

    await axios.post("/api/cert", formData);

    ClearInputs();
    await GetData();
    updateView();
}

function downloadCert(number) 
{
    window.open(`/api/cert/${number}/download`, "_blank");
}

function InvalidInput() 
{
    return model.inputs.type == "" || model.inputs.number == "" || model.inputs.notifiedbody == "" || model.inputs.issueDate == "" || model.inputs.expiryDate == "";
}

function ClearInputs() 
{
    model.inputs.type = "";
    model.inputs.number = "";
    model.inputs.notifiedbody = "";
    model.inputs.issueDate = "";
    model.inputs.expiryDate = "";
}

