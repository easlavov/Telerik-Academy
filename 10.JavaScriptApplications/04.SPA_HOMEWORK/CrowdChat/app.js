/// <reference path="scripts/_references.js" />
(function () {
    require.config({
        paths: {
            jquery: 'libs/jquery-2.1.1.min',
            handlebars: 'libs/handlebars-v1.3.0',
            q: 'libs/q',
            mocha: 'libs/mocha',
            chai: 'libs/chai',
            sammy: 'libs/sammy',
            underscore: 'libs/underscore-min',
            'http-requester': 'scripts/http-requester'
        }
    });

    require(['sammy', 'http-requester', 'handlebars', 'underscore'],
        function (sammy, requester, handlebars, _) {
            var app = sammy('#main-div', function () {
                this.get('#/', function () {
                });

                this.get('#/view-messages', function () {
                    var $mainDiv, defList, url;

                    $mainDiv = $('#main-div');
                    $mainDiv.empty();
                    $mainDiv.append('<p>').text('Displaying last 10 posts:');
                    defList = $('<dl>');
                    url = 'http://crowd-chat.herokuapp.com/posts';
                    requester.getJson(url)
                        .then(function (posts) {
                            var lastPosts, handlebarsSource, template, html, post;
                            lastPosts = _.last(posts, 20);
                            handlebarsSource = $('#post-template').html();
                            template = Handlebars.compile(handlebarsSource);
                            for (var i in lastPosts) {
                                post = lastPosts[i];
                                html = template(post);
                                defList.append(html);
                            }

                            defList.appendTo($mainDiv);
                        });

                });

                this.get('#/post-message', function () {
                    var $mainDiv, handlebarsSource, template, html;
                    $mainDiv = $('#main-div');


                    handlebarsSource = $('#post-message-form-template').html();
                    template = Handlebars.compile(handlebarsSource);
                    html = template();
                    $mainDiv.append(html);

                    $('#submit-post-button').on('click', function () {
                        var name, message, url, jsonObj;
                        name = $('#name-input').val();
                        message = $('#text-input').val();
                        url = 'http://crowd-chat.herokuapp.com/posts';
                        jsonObj = {
                            user: name,
                            text: message
                        };
                        requester.postJson(url, jsonObj)
                        .then(function () {
                            console.log('Successfully posted!');
                        });
                    });
                });
            });

            app.run('#/');
        });
})();