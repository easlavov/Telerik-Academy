(function () {
    require.config({
        paths: {
            'jquery': '../libs/jquery-2.1.1',
            'handlebars': '../libs/handlebars-v1.3.0',
            'people': 'people',
            'controls': 'controls'
        }
    });

    require(['controls', 'people', 'jquery'], function (controls, people) {
        // Refactor:
        var comboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        var comboBoxHtml = comboBox.render(template);
        var $container = $('#combobox-container');
        $container.append(comboBoxHtml);
    });
}());