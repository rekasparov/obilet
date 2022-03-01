$(() => {
    var selectFrom, selectTo, txtDate, btnToday, btnTomorrow, btnChangeLocation, btnSearchTicket;

    $(document).ready(() => {
        init();

        $(btnToday).on('click', () => {
            btnToday_onClick();
        });

        $(btnTomorrow).on('click', () => {
            btnTomorrow_onClick();
        });

        $(btnChangeLocation).on('click', () => {
            btnChangeLocation_onClick();
        });

        $(btnSearchTicket).on('click', () => {
            btnSearchTicket_onClick(event);
        });

        btnToday_onClick = (e) => {
            setDate();
            changeDayButtonStyle(btnTomorrow, btnToday);
        };

        btnTomorrow_onClick = (e) => {
            setDate(1);
            changeDayButtonStyle(btnToday, btnTomorrow);
        };

        btnChangeLocation_onClick = (e) => {
            var fromData = getCurrentData(selectFrom);
            var toData = getCurrentData(selectTo);

            if (fromData === false || toData === false) return false;

            changeLocation(selectFrom, selectTo, fromData, toData);
        };

        btnSearchTicket_onClick = (e) => {
            if (!isValid()) e.preventDefault();
            else {
                saveUserSelection();
                redirectToHome();
            }
        };
    });

    redirectToHome = () => {
        var entries = getFormData();

        var paremeter = 'originId=' +
            entries.selectedFromVal +
            '&destinationId=' +
            entries.selectedToVal +
            '&departureDateStr=' +
            convertDate(entries.selectedDate);

        window.location.href = '/Home?' + paremeter;
    };

    convertDate = (d) => {
        var date = moment(d, 'DD.MM.YYYY').format('MM.DD.YYYY');

        return date;
    };

    changeLocation = (d, l, f, t) => {
        $(d)
            .empty()
            .append($('<option selected />')
                .val(t.val)
                .text(t.text))
            .val(t.val)
            .trigger('change');

        $(l)
            .empty()
            .append($('<option selected />')
                .val(f.val)
                .text(f.text))
            .val(f.val)
            .trigger('change');
    };

    getCurrentData = (e) => {
        var val = $(e).select2('data')[0].id;
        var text = $(e).select2('data')[0].name;

        if (text == null || text == undefined || text == '') text = $(e).select2('data')[0].text;

        if (val == null || val == undefined || val == '' || val == 0) return false;
        else if (text == null || text == undefined || text == '') return false;

        var data = {
            val: val,
            text: text
        };

        return data;
    };

    setDate = (d) => {
        var date = getDate(d);

        txtDate.data('baseDate', date.baseDate);
        txtDate.val(date.formattedDate);
    };

    getDate = (d) => {
        if (d == undefined || d == null || d == '') d = 0;
        var momentDate = moment().add(d, 'days');
        var baseDate = momentDate.format('DD.MM.YYYY');
        var formattedDate = momentDate.format('DD MMMM YYYY dddd');

        var date = {
            momentDate: momentDate,
            baseDate: baseDate,
            formattedDate: formattedDate
        };

        return date;
    };

    init = () => {
        btnToday = $('#btnToday');
        btnTomorrow = $('#btnTomorrow');
        btnChangeLocation = $('#btnChangeLocation');
        btnSearchTicket = $('#btnSearchTicket');

        selectFrom = $('#selectFrom');
        selectTo = $('#selectTo');
        txtDate = $('#txtDate');

        setDate(1);

        getUserSelection();
    };

    changeDayButtonStyle = (s, t) => {
        $(s).removeClass('btn-indigo-100').addClass('btn-outline-indigo-100');
        $(t).removeClass('btn-outline-indigo-100').addClass('btn-indigo-100');
    };

    showError = (e) => {
        new Noty({
            text: e,
            type: 'error',
            theme: 'limitless',
            layout: 'topRight',
            timeout: 2500
        }).show();
    };

    isValid = () => {
        var selectedFromVal = $(selectFrom).val();
        var selectedToVal = $(selectTo).val();

        if (selectedFromVal == 0 || selectedFromVal == '' || selectedFromVal == undefined) {
            showError('Kalkış Noktası boş bırakılamaz!');
            return false;
        }
        else if (selectedToVal == 0 || selectedToVal == '' || selectedToVal == undefined) {
            showError('Varış Noktası boş bırakılamaz!');
            return false;
        }
        else if (selectedFromVal == selectedToVal) {
            showError('Kalkış ve Varış noktaları aynı olamaz!');
            return false;
        }

        var currentDate = getDate(-1).momentDate;
        var selectedDate = moment(txtDate.data('baseDate'), 'DD.MM.YYYY');

        if (selectedDate < currentDate) {
            showError('Yolculuk tarihi geçmiş tarihli seçilemez!');
            return false;
        }

        return true;
    };

    getFormData = () => {
        var fromData = getCurrentData(selectFrom);
        var toData = getCurrentData(selectTo);

        var selectedFromVal = fromData.val;
        var selectedToVal = toData.val;
        var selectedFromText = fromData.text;
        var selectedToText = toData.text;


        var selectedDate = moment(txtDate.data('baseDate'), 'DD.MM.YYYY').format('DD.MM.YYYY');

        var entries = {
            selectedFromVal: selectedFromVal,
            selectedToVal: selectedToVal,
            selectedFromText: selectedFromText,
            selectedToText: selectedToText,
            selectedDate: selectedDate
        };

        return entries;
    };

    saveUserSelection = () => {
        var entries = getFormData();

        var jsonData = JSON.stringify(entries);

        document.cookie = 'entries=' + jsonData;
    };

    getUserSelection = () => {
        var cookie = document.cookie;

        if (cookie.indexOf('entries=') != -1) {
            var startIndex = cookie.indexOf('entries=') + 8;
            var jsonData = cookie.substring(startIndex, cookie.length);
            var entries = JSON.parse(jsonData);

            setUserSelection(entries);
        }
    };

    setUserSelection = (e) => {
        $(selectFrom)
            .empty()
            .append($('<option selected />')
                .val(e.selectedFromVal)
                .text(e.selectedFromText))
            .val(e.selectedFromVal)
            .trigger('change');

        $(selectTo)
            .empty()
            .append($('<option selected />')
                .val(e.selectedToVal)
                .text(e.selectedToText))
            .val(e.selectedToVal)
            .trigger('change');

        var selectedDate = moment(e.selectedDate, 'DD.MM.YYYY');
        var baseDate = selectedDate.format('DD.MM.YYYY');
        var formattedDate = selectedDate.format('DD MMMM YYYY dddd');

        txtDate.data('baseDate', baseDate);
        txtDate.val(formattedDate);
    };
});