(function () {
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            students: 'students'
        }
    });

    require(['students', 'jquery'], function (students) {

        $('#get-students-button').on('click', getAndPrintStudents);
        $('#submit-student-info').on('click', addStudent);
        $('#submit-delete-info').on('click', deleteStudent);

        function getAndPrintStudents() {
            students.getStudents()
                .then(printStudents);

            function printStudents(students) {
                var $container, $list;
                students = students.students;
                $container = $('#students-list');

                $container.empty();
                $list = $('<ul>');
                for (var i in students) {
                    $list.append($('<li>').html(students[i].id + ' ' + students[i].name));
                }

                $list.appendTo($container);
            }
        }

        function addStudent() {
            var name, grade;
            name = $('#student-name-input').val();
            grade = $('#student-grade-input').val();
            grade = parseInt(grade);
            students.addStudent(name, grade)
                .then(printFeedback);
        }

        function deleteStudent() {
            var id;
            id = $('#student-id-input').val();
            id = parseInt(id);
            students.deleteStudents(id)
                .then(printFeedback);
        }

        function printFeedback(serverMessage) {
            serverMessage = JSON.stringify(serverMessage);
            var $feedbackContainer = $('#server-feedback-div');
            var $info = $('<p>').text(serverMessage);
            $feedbackContainer.append($info);
        }
    })
})();