window.dialogService = {
    show: function (modalId) {
        const modalEl = document.getElementById(modalId);
        if (modalEl) {
            const modal = new Modal(modalEl);
            modal.show();
            console.log("dialog showed");
        }
    },
    hide: function (modalId) {
        const modalEl = document.getElementById(modalId);
        if (modalEl) {
            const modal = new Modal(modalEl);
            modal.hide();
            console.log("dialog hided");
        }
    },
    toggle: function (modalId) {
        const modalEl = document.getElementById(modalId);
        if (modalEl) {
            const modal = new Modal(modalEl);
            modal.toggle();
            console.log("dialog toggled");
        }
    }
};