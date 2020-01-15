开发环境：
visual studio 2017
.net framework 4.5.2
c#
-------------------------------------------------------------------------------------------------------
依赖库：
如果从github上下载本项目，需要运行以下nuget命令：
Install-Package CefSharp.WinForms -ProjectName Greatzee.Spider.Winform -Version 75.1.143

如果要运行示例目标网站，请运行以下nuget命令
Install-Package Microsoft.AspNet.Mvc.zh-Hans -ProjectName SiteDemo  -Version 5.2.7
Install-Package Microsoft.AspNet.Razor.zh-Hans -ProjectName SiteDemo  -Version 3.2.7
Install-Package Microsoft.AspNet.WebPages.zh-Hans -ProjectName SiteDemo -Version 3.2.7
Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -ProjectName SiteDemo -Version 2.0.1
Install-Package Microsoft.Web.Infrastructure -ProjectName SiteDemo -Version 1.0.0.0

-------------------------------------------------------------------------------------------------------
解决方案文件说明：
Greatzee.Spider.Winform为爬虫的主程序，部署到生成环境时应该只留这一个程序
SiteDemo是用于调试和学习的目标网站，运行Greatzee.Spider.Winform会到这个网站爬取页面
SocketStorage是用于调试和学习的html存储的应用程序，运行Greatzee.Spider.Winform会将爬取到的html字符串发送给这个应用程序

-------------------------------------------------------------------------------------------------------
配置文件位置：
Greatzee.Spider.Winform/SpiderConfig
-----------------------------------------------------------
action.xml
action(爬虫动作)总览。示例如下：

<?xml version="1.0" encoding="utf-8" ?>
<config>
  <!--周期间隔(毫秒)，小于0为无周期-->
  <execute_interval>30000</execute_interval>
  <!--动作间隔(毫秒)-->
  <action_interval>100</action_interval>
  <actions>
    <file_name>login.action</file_name>
    <file_name>nopaging.action</file_name>
    <file_name>paging.action</file_name>
  </actions>
</config>

----------------------------------------------------------
*.action
动作文件，一个action模拟用户在网站上执行一次查询，示例如下：

<?xml version="1.0" encoding="utf-8" ?>
<!--
  为使配置标准化，请遵循以下约定：
  1：此xml文件中的所有标签都不能缺少，但可以是空标签对；
  2：二级节点的顺序逻辑上可以随意，但按search_page_url,result_page_url_regex,storage_api,storage_socket,storage_local_directory,script的顺序比较容易理解；
  3：四个script节点的name属性必须是greatzee_register_parameter，greatzee_execute_search，greatzee_has_next_page，greatzee_goto_next_page之一，且不能重复
  4：四个script节点中的函数名称必须与标签的name属性一模一样的，且不可缺少。
  5：四个命名函数无逻辑时请按以下方式编写
      function greatzee_register_parameter(){
        retun null;
      }
      function greatzee_execute_search(){
      
      }
      function greatzee_has_next_page(){
        return false;
      }
      function greatzee_goto_next_page(){
      
      }
   6：所有的javascript代码必须严格遵循ECMAScript6标准。
-->
<action name="产品_红色化妆品">
  <!--网页使用的编码格式-->
  <charset>utf-8</charset>
  <!--引导爬虫进入查询页面-->
  <search_page_url><![CDATA[http://localhost:62972/Home/Products]]></search_page_url>

  <!--用于拦截结果页面url的正则表达式-->
  <result_page_url_regex><![CDATA[^http://localhost:62972/Home/Products$]]></result_page_url_regex>
  
  <!--存储爬行结果的webapi地址-->
  <storage_api></storage_api>

  <!--存储爬行结果的socket地址-->
  <storage_socket>127.0.0.1:9022</storage_socket>

  <!--存储爬行结果的本地操作系统文件夹(如：F:\html)-->
  <storage_local_directory></storage_local_directory>

  <!--
  greatzee_register_parameter函数会最先被爬虫引擎执行，返回一个json对象，爬虫引擎会将该对象赋值给全局变量$RegisterParameter
  $RegisterParameter有以下两个作用：
      1:其它javascript代码可以直接使用$RegisterParameter对象
      2:$RegisterParameter对象会被爬虫引擎序列化成一个字符串，附加在html字符串后面一期传给负责存储的应用程序使用（storage_api,storage_socket,storage_local_directory），这些应用程序可以根据这个字符串进行归类去重等操作
  -->
  <script name="greatzee_register_parameter">
    <![CDATA[
      function greatzee_register_parameter(){
        var parameter={productType:"化妆品",color:"白色"};
        return parameter;
      }
    ]]>
  </script>
  
  <!--greatzee_execute_search函数用于在search_page中填充查询参数和提交页面-->
  <script name="greatzee_execute_search">
    <![CDATA[
       function greatzee_execute_search(){
        document.getElementById("productType").value = $RegisterParameter.productType;
        document.getElementById("color").value = $RegisterParameter.color;
        document.getElementsByTagName("form")[0].submit();
      }
    ]]>
  </script>

  <!--
   greatzee_has_next_page函数通知爬虫引擎是否还有下一页。
   通常用于解决数据分页显示的问题。
   如果没有分页则应直接返回false。
   如果有分页，应该从dom、url或cookie中分析出数据总页数和当前页码，根据总页数和当前页码判断是否还有下一页，如果有则返回true，否则返回false。
  -->
  <script name="greatzee_has_next_page">
    <![CDATA[
       function greatzee_has_next_page(){
        return false;
      }
    ]]>
  </script>
  
  <!--greatzee_goto_next_page函数需模拟出用户在页面上点“下一页”的动作，如document.getElementById("next_page").click();-->
  <script name="greatzee_goto_next_page">
    <![CDATA[
      function greatzee_goto_next_page(){
      
      }
      ]]>
  </script>
</action>



