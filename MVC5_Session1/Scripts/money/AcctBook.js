function cleanUpFrm() {
    $("input[name='money']").val('');
    $("textarea[name='description']").val('');
    $("input[name='date']").val('');
    $("select[name='category']").prop('selectedIndex', 0);
}
