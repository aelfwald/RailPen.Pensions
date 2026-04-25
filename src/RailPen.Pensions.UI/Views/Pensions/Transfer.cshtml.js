function submitTransfer() {
    var form = $('#transferForm');

    $.ajax({
        url: form.attr('action'),
        type: 'POST',
        data: form.serialize(),
        success: function(response) {
            if (response.success) {
                $('#editModal').modal('hide');
                location.reload();
            }
            else {
                alert(response.message);
            }
        },
        error: function(xhr) {
            alert('An error occurred while processing the transfer.');
        }
    });
}

function closeModal() {
    $('#editModal').modal('hide');
}

function enforceMinMaxStep(el) {
    var min = parseFloat(el.min);
    var max = parseFloat(el.max);
    var step = parseFloat(el.step);

    // If blank or empty, 
    if (el.value == "" || el.value == null) {
        el.value = 0;
        return;
    }

    var value = parseFloat(el.value);

    if (!isNaN(value)) {
        // Enforce min
        if (value < min) {
            el.value = min.toFixed(2);
            return;
        }

        // Enforce max
        if (value > max) {
            el.value = max.toFixed(2);
            return;
        }

        // Enforce step - round to nearest valid step value
        if (step && !isNaN(step)) {
            var steppedValue = Math.round(value / step) * step;
            // Round to avoid floating point precision issues
            el.value = steppedValue.toFixed(2);
        }
    } else {
        // If invalid value, set to min
        el.value = min.toFixed(2);
    }
}

$('#editModal').on('hidden.bs.modal', function () {
    $('#modalWrapper').empty();
});
