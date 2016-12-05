// Write your Javascript code.
function PageClicked(page) {
    $('#Page').val(page);
    $('#PagedForm').submit();
}

function EvalPreviousNext(page, total){
    if (page === 0)
        $('#Previous').addClass('is-disabled');
    else
        $('#Previous').removeClass('is-disabled');

    if (page === (total - 1))
        $('#Next').addClass('is-disabled');
    else
        $('#Next').removeClass('is-disabled');
}



