export function initializeDatepicker(elementId) {
    const $datepickerEl = document.getElementById(elementId);

    const options = {
        format: 'dd/mm/yyyy',
        orientation: 'bottom',
        autohide: true,
        buttons: true,
        rangePicker: true,
    };

    const instanceOptions = {
        id: elementId,
        override: true
    };

    const datepicker = new Datepicker($datepickerEl, options, instanceOptions);

    // Optional: Expose methods for interop if needed
    window.datepicker = datepicker;
}
