var FrameworkInit = function () {
    var daterange = () => {
        $('.daterange-single').daterangepicker({
            parentEl: '.content-inner',
            singleDatePicker: true,
            locale: {
                format: 'DD MMMM YYYY dddd'
            }
        }, (s, e, l) => {
            $('.daterange-single').data('baseDate', s.format('DD.MM.YYYY'));
        });
    };

    var select2 = () => {
        $('.select-remote-data').select2({
            ajax: {
                url: 'http://localhost:41399/Landing/GetSearchResults',
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        q: params.term,
                        page: params.page
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;

                    return {
                        results: data.items,
                        pagination: {
                            more: (params.page * 30) < data.total_count
                        }
                    };
                },
                cache: true
            },
            escapeMarkup: function (markup) { return markup; },
            minimumInputLength: 1,
            templateResult: formatRepo,
            templateSelection: formatRepoSelection
        });
    };

    formatRepo = (repo) => {
        if (repo.loading) return repo.text;

        var markup = '<div class="select2-result-repository__title">' + repo.name + '</div>';

        return markup;
    };

    formatRepoSelection = (repo) => {
        return repo.name || repo.text;
    };

    return {
        init: function () {
            daterange();
            select2();
        }
    }
}();

document.addEventListener('DOMContentLoaded', function () {
    FrameworkInit.init();
});