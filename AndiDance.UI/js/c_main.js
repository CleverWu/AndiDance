//登录页
$(function(){
    $('.login-box').css('margin-top',($(window).height()-315)/2);
    $('.loginContainer').css('height',($(window).height()));
})
//以下为angular
var app = angular.module('AnDi', []);
// 主页index控制器
app.controller('homeController', function($scope,$http) {
    $http.get('/dist/AndiDanceFrontend/andi/js/100.json')
        .success(function(data) {
            $scope.classSituations = data;
        });
    $http.get('/dist/AndiDanceFrontend/andi/js/200.json')
        .success(function(data) {
            $scope.todayCourses = data;
        });
    // 操作处理弹框
    $scope.memberListTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.memberListTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.memberListTc').css("display","none");
            }
        });
    }
    $scope.makeNew=true;
    //操作弹框
    $scope.memberHander=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.mainMemberHandle'), //捕获的元素
            end:function () {
                $scope.makeNew=true;
                console.log("end",$scope.makeNew)
            }
        });
    }
    //会员扣课
    $scope.deductCourse=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.deductCourse'), //捕获的元素
        });
    }
    // 会员签单
    $scope.chooesPackage=function () {
        window.location.href='./choosePackage.html'
    }
});
// 增加会员页面控制器
app.controller('addMemberController', function($scope) {
   // 刷新办会员卡弹框
    $scope.refreshCarda=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.commonPopUp'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.commonPopUp').css("display","none");
            }
        });
    }
    // 绑定成功后的弹框
    $scope.bindCarda=function(){
        CommonUtils.tips_handle("恭喜您,成功创建会员：李天际，卡号254545",function(){

        })
    }
});
// 会员信息控制器
app.controller('memberInfo', function($scope) {
    $scope.switch=true;
    // 延迟套餐时间
    $scope.packageDelayTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.packageDelayTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.packageDelayTc').css("display","none");
            }
        });
    }
    // 退款弹窗
    $scope.packageRefundTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.packageRefundTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.packageRefundTc').css("display","none");
            }
        });
    }
    // 执行套餐
    $scope.applyPackageTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.applyPackageTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.applyPackageTc').css("display","none");
            }
        });
    }
    // 冻结套餐
    $scope.freezePackageTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.freezePackageTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.freezePackageTc').css("display","none");
            }
        });
    }

});
// 套餐详情控制器
app.controller('packagesDetail', function($scope) {
    // 操作记录
    $scope.actionRecordTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.actionRecordTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.actionRecordTc').css("display","none");
            }
        });
    }
    // 延迟套餐时间
    $scope.packageDelayTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.packageDelayTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.packageDelayTc').css("display","none");
            }
        });
    }
    // 退款弹窗
    $scope.packageRefundTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.packageRefundTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.packageRefundTc').css("display","none");
            }
        });
    }
    // 执行套餐
    $scope.applyPackageTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.applyPackageTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.applyPackageTc').css("display","none");
            }
        });
    }
    // 冻结套餐
    $scope.freezePackageTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.freezePackageTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.freezePackageTc').css("display","none");
            }
        });
    }
});
// 所有员工列表控制器
app.controller('allEmployees', function($scope,CommonUtils) {
    // 删除员工
    $scope.cancelEmploye=function () {
        CommonUtils.tips_handle("是否删除员工",function () {
            
        })
    }
});
// 员工信息控制器
app.controller('employeeDetail', function($scope,CommonUtils) {
   $scope.switch=true;
    // 代课弹框
    $scope.substitute=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.substitute'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.substitute').css("display","none");
            }
        });
    }
    // 停课弹框
    $scope.closeClass=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.closeClass'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.closeClass').css("display","none");
            }
        });
    }
    // 离职说明弹框
    $scope.closeClass=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.closeClass'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.closeClass').css("display","none");
            }
        });
    }
    // 停课弹框
    $scope.leaveOffice=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.leaveOffice'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.leaveOffice').css("display","none");
            }
        });
    }

});
// 增加教室控制器
app.controller('addClassRoom', function($scope,CommonUtils) {
    // 增加教室（房间）弹框
    $scope.addClassRoomTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.addClassRoomTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.addClassRoomTc').css("display","none");
            }
        });
    }
    // 编辑教室（房间）弹框
    $scope.editClassRoomTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.editClassRoomTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.editClassRoomTc').css("display","none");
            }
        });
    }
    // 教室使用情况
    $scope.classRoomUse=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.classRoomUse'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.classRoomUse').css("display","none");
            }
        });
    }


});
// 套餐设置控制器
app.controller('packageSetting', function($scope,CommonUtils) {
    $scope.isActive=true;

});
// 增加套餐控制器
app.controller('addPackage', function($scope,CommonUtils) {


});
// 套餐设置详情
app.controller('packageSetDetail', function($scope,CommonUtils) {
    $scope.switch=true;

});
// 课程设置控制器
app.controller('courseSet', function($scope,CommonUtils) {
    $scope.isActive=true;

});
// 添加课程控制器
app.controller('addCourse', function($scope,CommonUtils) {
    $scope.isActive=true;
    // 增加教室（房间）弹框
    $scope.addCourseTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.addCourseTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.addCourseTc').css("display","none");
            }
        });
    }

});
// 课程详情控制器
app.controller('courseDetail', function($scope,CommonUtils) {
    $scope.switch=true;
    // 修改课程弹框
    $scope.editCourseTc=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.addCourseTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.addCourseTc').css("display","none");
            }
        });
    }
});
// 活动设置控制器
app.controller('activitySet', function($scope,CommonUtils) {
    $scope.isActive=true;

});
// 添加活动控制器
app.controller('addActivity', function($scope,CommonUtils) {

});
// 活动详情控制器
app.controller('activityDetail', function($scope,CommonUtils) {
    $scope.switch=true;
    // 添加活动至套餐
    $scope.bindPackage=function () {
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.bindPackage'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.bindPackage').css("display","none");
            }
        });
    }

});
// 会员财务控制器
app.controller('memberFinance', function($scope,CommonUtils) {
    $scope.isActive=true;
    $scope.chargeValueFinance=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.chargeValueFinance'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.chargeValueFinance').css("display","none");
            }
        });
    }
});
// 套餐签单情况控制器
app.controller('packageBillRecord', function($scope,CommonUtils) {
    $scope.packageRecordTc=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.packageRecordTc'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.packageRecordTc').css("display","none");
            }
        });
    }
});
// 课程安排情况控制器
app.controller('courseSchedule', function($scope,CommonUtils) {
    $scope.isActive=1;
});


// 以下为公共控制器，多个页面会使用
app.controller('cMain', function($scope,CommonUtils) {
    $scope.isCreat=true;
    $scope.goIndex=function () {
        window.location.href="./index.html"
    }
    $scope.chooesPackage=function () {
        window.location.href="../../choosePackage.html"
    }
    $scope.cancelAll=function () {
        layer.closeAll();
    }
    //左侧导航栏
    $scope.navList=[
        {id:0,title:'门店首页',content:[]},
        {id:1,title:'门店会员',content:[]},
        {id:2,title:'公司管理',content:[{'subName':'员工列表','link':'./allEmployees.html'},{'subName':'权限设置','link':'./quanxian.html'},{'subName':'教室设置','link':'./jiaoshi.html'}]},
        {id:3,title:'套餐课程',content:[{'subName':'套餐设置','link':'./taochanshezhi.html'},{'subName':'课程模板','link':'./kechengmoban.html'},{'subName':'课程设置','link':'./kechengshezhi.html'},{'subName':'活动设置','link':'./huodongshezhi.html'}]},
        {id:4,title:'财务系统',content:[{'subName':'会员财务','link':'./huiyuancaiwu.html'},{'subName':'签单情况','link':'./qiandanqingkuang.html'}]},
        {id:5,title:'报表管理',content:[{'subName':'会员情况','link':'./huiyuanqingkuang.html'},{'subName':'课程安排','link':'./kechenganpai.html'},{'subName':'上课统计','link':'./shangketongji.html'}]}
    ]
    $scope.navIndex=-1;
    $scope.isActive=function(index){
        $scope.navIndex=index;
    }

    //会员充值（多个页面会用）
    $scope.chargeValue=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.chargeValue'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.chargeValue').css("display","none");
            }
        });
    }
    //会员选课测试数据及弹框（多个页面会用）
    //选课
    $scope.tab=1;
    $scope.week1s=[
        {week:"周一",checked:false,courseName:"街舞基础课",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"基础版",courseType:"基础版"}
    ]
    $scope.week2s=[
        {week:"周二",checked:false,courseName:"街舞进阶1",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.week3s=[
        {week:"周三",checked:false,courseName:"街舞进阶2",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.week4s=[
        {week:"周四",checked:false,courseName:"街舞进3",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.week5s=[
        {week:"周五",checked:false,courseName:"街舞进阶4",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.week6s=[
        {week:"周六",checked:false,courseName:"街舞进阶5",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.week7s=[
        {week:"周日",checked:false,courseName:"街舞进阶6",teacher:"李天牛",time:"9:00-10:00",danceType:"街舞",payCourseTime:"3课时",classType:"进阶版",courseType:"进阶版"}
    ]
    $scope.chooseCourse=function(){
        layer.closeAll();
        layer.open({
            type: 1,
            shade: 0.3,
            shadeClose:true,
            closeBtn: 0,
            area: ['auto', 'auto'], //宽高
            title: false, //不显示标题
            content: $('.selectCourse'), //捕获的元素
            cancel: function(index){
                layer.close(index);
                this.content.show();
                $('.selectCourse').css("display","none");
            }
        });
    }
});

