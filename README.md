ASP.NET MVC 購物網功能實作
=======================
> ## 說明:
這是下班之餘跟著網路資源自學ASP.NET MVC所做的購物網站功能實作

> ## 使用技術:
1.後端 :
* .Net Framework MVC框架
* Entity Framework 這裡使用DB first，使用MSSQL的LocalDB
- [Web API 提供前端使用](#7)
* Identity 身分驗證功能

2.前端 :
* HTML/CSS/JS
* bootstrap
- [AJAX介接Web API更新購物車內容](#7)

> ## 功能說明 :
1. 這個頁面是還未有登入驗證的初始頁面，這個頁面列出所有的品項，若點擊加入購物車則會提示用戶必須要登入。
![avatar](https://i.imgur.com/TebqcSP.png)

2. 之後會進入到登入的頁面，可以註冊或是現有的用戶登入。
![avatar](https://i.imgur.com/FLHFJhZ.png)

3. 如果登入的使用者判定為系統管理員，則會進入系統管理的頁面，這裡可以看到導覽列發生改變，導覽列會隨著用戶的權限而改變，目前畫面上的導覽列是系統管理員權限所看到的。
![avatar](https://i.imgur.com/3bMUt3U.png)

4. 產品管理的頁面使用ViewModel來顯示頁面資訊，選擇產品類別會更新品項的表格。
![avatar](https://i.imgur.com/2PslxWY.png)

5. 系統管理員可以管理所有的會員，這裡會顯示所有的會員，並且觀看會員的詳細資訊。
![avatar](https://i.imgur.com/qOzX51g.png)
![avatar](https://i.imgur.com/X23ZIc2.png)

6. 系統管理員也可以查看訂單資料，表格中的狀態欄位，若下拉選單有變動，前端對應用戶的訂單資料會跟著更新，達到訂單狀態會隨著出貨付款而改變。
![avatar](https://i.imgur.com/ZRGxjPP.png)
![avatar](https://i.imgur.com/FxmoZk6.png)

<h4 id="7">7. 這是前端的購物車，這裡使用Web API跟資料庫取資料，其中"+"、"-"、"刪除"按鈕使用AJAX更新購物車資訊，這裡因為是一般用戶，所以導覽列跟前面系統管理員看到的導覽列有所不同。</h4>

![avatar](https://i.imgur.com/tny3d2P.png)

8. 訂單資訊
![avatar](https://i.imgur.com/ZyBihsW.png)
![avatar](https://i.imgur.com/3LMEO0h.png)

9. 產品
![avatar](https://i.imgur.com/qhyvxR3.png)


