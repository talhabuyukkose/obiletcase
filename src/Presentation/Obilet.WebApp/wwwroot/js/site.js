// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    // Butona tıklandığında
    $('#SearchFormButton').on('click', function () {
        // Formu gönder
        $('#SearchForm').submit();
    });

    // Form içinde herhangi bir input alanına Enter tuşu basıldığında
    $('#SearchForm').on('keypress', 'input', function (e) {
        if (e.which === 13) { // Enter tuşu (keyCode: 13)
            e.preventDefault(); // Formun otomatik gönderilmesini engelle
            // $('#SearchFormButton').click(); // Butona tıklama işlemini tetikle
        }
    });
});

// Today and Tomorrow Code.
$(document).ready(function () {
    $("#todayButton").on("click", function () {
        setDateToInput(getFormattedDate(new Date()));
    });

    $("#tomorrowButton").on("click", function () {
        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        setDateToInput(getFormattedDate(tomorrow));
    });

    function setDateToInput(date) {
        $("#dateInput").val(date);
    }

    function getFormattedDate(date) {
        var day = ("0" + date.getDate()).slice(-2);
        var month = ("0" + (date.getMonth() + 1)).slice(-2);
        var year = date.getFullYear();
        return year + "-" + month + "-" + day;
    }
});


// Sayfa yüklendiğinde var olan dropdown öğeleri için event listener
$('.dropdown-menu a').click(function () {
    handleDropdownClick($(this));
});

// Yeni eklenen dropdown öğeleri için event delegation
$(document).on('click', '.dropdown-menu a', function () {
    handleDropdownClick($(this));
});


function handleDropdownClick(clickedElement) {
    var dropdownId = clickedElement.closest('.dropdown').attr('id');

    var selectedValue = clickedElement.text();
    var selectedId = clickedElement.data('value');

    $('#' + dropdownId + 'Input').val(selectedValue);
    $('#' + dropdownId + 'InputForId').val(selectedId);

    if ($('#originDropdownInputForId').val() === $('#destinationDropdownInputForId').val()) {
        $('#' + dropdownId + 'Input').val('');
        $('#' + dropdownId + 'InputForId').val(0);
        toastr.error('Varış ve kalkış noktası aynı olamaz lütfen yeniden giriniz', 'Warning', {
            timeout: 20000,
            positionClass: 'toast-bottom-right',
            toastClass: 'custom-toast'
        });
    }
}


// OriginSearch remove and add dropdown
function OriginSearch() {
    var searchvalue = $("#originDropdownInput").val();

    $('#originDropdown').on('shown.bs.dropdown', function () {
        $(this).find('.dropdown-menu a:first').focus();
    });

    $.ajax({
        type: "POST",
        url: "/Home/SearchLocations",
        data: {searchvalue: searchvalue},
        // contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            removeLiFromDropDown('#originDropdown ul li');
            AddLiToDropDown('#originDropdown ul', result);
        },
        error: function (err) {
            console.log(err);
        }
    });


}

// DestinationSearch remove and add dropdown
function DestinationSearch() {
    const searchvalue = $("#destinationDropdownInput").val();


    $.ajax({
        type: "POST",
        url: "/Home/SearchLocations",
        data: {searchvalue: searchvalue},
        // contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            removeLiFromDropDown('#destinationDropdown ul li');
            AddLiToDropDown('#destinationDropdown ul', result);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function AddLiToDropDown(element, locations) {

    locations.forEach(location => {
        // İlk dropdown menüsüne yeni öğeler ekle
        $(element).append('<li><a data-value="' + location.id + '" >' + location.value + '</a></li>');
    });
    $(element).trigger('create');
}

function removeLiFromDropDown(element) {
    $(document).ready(function () {
        // Tüm <li> öğelerini sil
        $(element).remove();
    });
}


//Origin and destination swap
function SwapOriginAndDestination() {
    var originSelect = document.getElementById("originDropdownInput");
    var destinationSelect = document.getElementById("destinationDropdownInput");

    var temp = originSelect.value;
    originSelect.value = destinationSelect.value;
    destinationSelect.value = temp;

    originSelect.dispatchEvent(new Event('change'));
    destinationSelect.dispatchEvent(new Event('change'));
}

