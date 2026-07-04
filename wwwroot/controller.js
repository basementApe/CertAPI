
// async function GetData() 
// {
//     const response = await axios.get("/api/test");
//     model.fullCertificateList = response.data;
//     // console.log(response.data);
// }

// async function PostData(cert) 
// {
//     const msg = await axios.post("/api/cert", cert);
// }

// async function SearchByType() 
// {
//     const response = await axios.get("/api/searchtype", { params: { type: model.searchByType } });
//     model.searchResults = response.data;
//     updateView();
// }

// async function SearchByNumber() 
// {
//     const response = await axios.get("/api/searchnumber", { params: { number: model.searchByNumber } });
//     model.searchResults = response.data;
//     updateView();
// }

// function ClearSearches() 
// {
//     model.searchByType = "";
//     model.searchByNumber = -1;
// }

// function SubmitAll() 
// {
//     if (InvalidInput()) 
//     {
//         alert("All fields must be filled in.");
//         return;
//     }

//     const cert =
//     {
//         type: model.inputs.type,
//         number: model.inputs.number,
//         notifiedBody: model.inputs.notifiedbody,
//         issueDate: model.inputs.issueDate,
//         expiryDate: model.inputs.expiryDate,
//     }

//     PostData(cert);
//     ClearInputs();
//     updateView();
// }

// function InvalidInput() 
// {
//     return model.inputs.type == "" || model.inputs.number == null || model.inputs.notifiedbody == "" || model.inputs.issueDate == "" || model.inputs.expiryDate == "";
// }

// function ClearInputs() 
// {
//     model.inputs.type = "";
//     model.inputs.number = null;
//     model.inputs.notifiedbody = "";
//     model.inputs.issueDate = "";
//     model.inputs.expiryDate = "";
// }

