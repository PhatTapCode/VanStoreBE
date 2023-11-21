function toggle(divId) {
    // Lấy ra tất cả các div
    var allDivs = document.querySelectorAll('#hiddenDiv1, #hiddenDiv2, #hiddenDiv3, #hiddenDiv4');

    // Ẩn tất cả các div
    allDivs.forEach(function (div) {
        div.classList.remove('thongtintaikhoan');
    });

    // Hiển thị div được chọn
    var selectedDiv = document.getElementById(divId);
    selectedDiv.classList.add('thongtintaikhoan');
}