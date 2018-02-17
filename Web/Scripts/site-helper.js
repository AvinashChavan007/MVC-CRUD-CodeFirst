$.ajaxSetup({ cache: false });

function SerializeAll(target) {
    var data = [];
    $(target).find('[name]').each(function () {

        var value = "";

        if ($(this).is(":checkbox"))
            value = ($(this).is(":checked") + "") || "";
        if (value === "")
            value = $(this).val() || "";
        if (value === "")
            value = $(this).data("value") || "";
        if (value === "" && !$(this).is("select"))
            value = $(this).text() || "";

        var name = $(this).attr("name");

        if ($.isArray(value)) {
            $.each(value, function (i, v) {
                data.push({ 'name': name, 'value': v.trim() });
            });
        } else if (value !== "" || !$(this).is("select")) {
            data.push({ 'name': name, 'value': value.trim() });
        }
    });
    return data;
}

var numerate = function (data) {
    var oldList = [];
    var newList = {};
    for (var i in data) {
        var newName = data[i].name.replace(/\[\]/g, '[0]');
        oldList.push({ name: newName, value: data[i].value });
    }
    while (oldList.length > 0) {
        var testData = oldList.shift();

        if (typeof newList[testData.name] !== "undefined") {
            var regex = /(.*\[)(\d+)(\].*)$/g;
            var regexValue = regex.exec(testData.name);
            if (regexValue !== null) {
                var oldValue = (regexValue[1] + regexValue[2] + "]"); //.replace(/(\[|\]|\.)/g, '\\$1');
                var number = 0;
                do {
                    if (number > 0)
                        number++;
                    else
                        number = parseInt(regexValue[2]) + 1;

                    testData.name = regexValue[1] + number + regexValue[3];
                } while (typeof newList[testData.name] !== "undefined")
                for (var e = 0; e < oldList.length; e++) {
                    //var regex2 = new RegExp("^" + oldValue + "(.*)", "g");
                    //var regex2Value = regex2.exec(oldList[i].name);
                    //if (regex2Value !== null) {
                    var oldLeft = oldList[e].name.indexOf(oldValue);
                    if (oldLeft === 0) {
                        //var oldRight = regex2Value[1];
                        var oldRight = oldList[e].name.substring(oldValue.length);
                        oldRight = oldRight.replace(/\[\d+\]/g, '[0]');
                        oldList[e].name = regexValue[1] + number + "]" + oldRight;
                        //}
                    }
                }
            }
        }
        newList[testData.name] = testData.value;
    }

    var returnData = $.map(newList, function (value, key) {
        return { name: key, value: value };
    });
    return returnData;
}

var unflatten = function (data) {
    "use strict";
    //if (Object(data) !== data || Array.isArray(data))
    //    return data;
    var regex = /\.?([^.\[\]]+)|\[(\d+)\]/g;
    var resultholder = {};

    for (var p in data) {
        var row = data[p];
        var cur = resultholder;
        var prop = "";
        var m;
        var countDictionary = {};
        while (m = regex.exec(row.name)) {
            cur = cur[prop] || (cur[prop] = (m[2] ? [] : {}));
            prop = m[2] || m[1];
        }
        cur[prop] = row.value;
    }
    return resultholder[""];
}
