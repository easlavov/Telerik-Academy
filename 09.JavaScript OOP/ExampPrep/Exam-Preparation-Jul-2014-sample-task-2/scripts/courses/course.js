define(function () {
    var Course;
    Course = (function () {
        function Course(name, totalScoreFormula) {
            this._students = [];
            this._totalScoreFormula = totalScoreFormula;
            this.name = name;
        }

        Course.prototype.addStudent = function (student) {
            this._students.push(student);
        };
        
        Course.prototype.calculateResults = function () {
            var self = this;
            this._students.forEach(function (student) {
                student.result = self._totalScoreFormula(student);
            })
        };

        Course.prototype.getTopStudentsByExam = function (count) {
            var topStudentsByExam = sortStudents(this._students, count, 'exam');
            return topStudentsByExam;
        };

        Course.prototype.getTopStudentsByTotalScore = function (count) {
            var topStudentsByTotalScore = sortStudents(this._students, count, 'result');
            return topStudentsByTotalScore;
        };

        function sortStudents(students, count, sortBy) {
            students.sort(function (firstStudent, secondStudent) {
                return secondStudent[sortBy] - firstStudent[sortBy];
            });
            return students.slice(0, count);
        }

        return Course;
    }());

    return Course;
});