define(function () {
    function addStudent(name, grade) {
        var deferred = $.Deferred();
        var newStudentData = {
            name: name,
            grade: grade
        };
        var url = 'http://localhost:3000/students';
        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newStudentData),
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (data) {
                deferred.reject(data);
            }
        });
        return deferred.promise();
    }

    function getStudents() {
        var deferred = $.Deferred();
        var url = 'http://localhost:3000/students';
        $.ajax({
            url: url,
            contentType: 'application/json',
            timeout: 5000,
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (data) {
                deferred.reject(data);
            }
        });
        return deferred.promise();
    }

    function deleteStudent(id) {
        var deferred = $.Deferred();
        var url = 'http://localhost:3000/students/' + id;
        $.ajax({
            url: url,
            type: 'POST',
            data: {_method: 'delete'},
            timeout: 5000,
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (data) {
                deferred.reject(data);
            }
        });
        return deferred.promise();
    }

    return {
        addStudent: addStudent,
        getStudents: getStudents,
        deleteStudents: deleteStudent
    }
});