taskName = "7. Parse URL. ";

function parseURL(url) {
    // extract protocol
    var index = url.indexOf(':');
    var protocol = url.substring(0, index);

    // extract server
    index += 3;
    var endIndex = url.indexOf('/', index);
    var server = url.substring(index, endIndex);

    // extract resource
    var resource = url.substring(endIndex + 1);

    // return JSON
    var urlObj = buildURL(protocol, server, resource);
    return urlObj;
}

function buildURL(protocol, server, resource) {
    return {
        protocol: protocol,
        server: server,
        resource: resource,
        toString: function () {
            return 'protocol: "' + protocol + '",' + '\n' +
                'server: "' + server + '",' + '\n' +
                'resource: "' + resource + '"'
        }
    }
}

// Test scripts
function Main(bufferElement) {
    var input = ReadLine(
        'Enter new text or use default: ',
        "http://www.devbg.org/forum/index.php");

    SetSolveButton(function () {
        var toExtract = input.value;
        var url = parseURL(toExtract);
        WriteLine(url.toString());
    });
}