function uploadFile(request, response) {
    response.end(request.url);
}

module.exports = {
    uploadFile: uploadFile
};