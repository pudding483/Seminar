// 名為 student 的物件
const directions = ["停", "前", "後", "左", "右"];

class student {
    // construct
    constructor(id) {
        this.id = id;
        this.status = "0";
    }
    getid() {
        return this.id;
    }
    getstatus() {
        return this.status;
    }
    move(way) {
        this.status = way;
    }
    // 顯示
    show() {
        document.getElementById("id_show").innerText = this.id;
    }
}
// 宣告一位 新學生 some_std 
var some_std;

// input的輸入
var input_box = document.getElementById("std_id"); //抓取 id = std_id 的「內容」
var submit_btn = document.querySelector(".submit"); //抓取 class = submit 的「物件」

// 監聽 submit_btn 的動作
submit_btn.addEventListener("click", function () {
    if (input_box.value.length != 9) {
        input_box.value = "";
        alert("wrong id");
        return;
    }
    some_std = new student(input_box.value);
    some_std.show();
});
