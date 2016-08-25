function cleanUpFrm() {
    $("input[name='money']").val('');
    $("textarea[name='description']").val('');
    $("input[name='date']").val('');
    $("select[name='category']").prop('selectedIndex', 0);
}
$.validator.addMethod("aftertoday", function (value, element, param) {
    if (value == null) {
        return true;
    }
    var sysDt = new Date();
    var usrDt = new Date(value);
    var curDt = new Date(sysDt.getFullYear(), sysDt.getMonth(), sysDt.getDate());
    usrDt.setHours(0);
    var sysNum = Date.parse(curDt);
    var usrNum = Date.parse(usrDt);
    if (usrNum > sysNum) {
        return false;
    } else {
        return true;
    }
});
$.validator.unobtrusive.adapters.addSingleVal("aftertoday", "input");