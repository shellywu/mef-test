### 微软MEF扩展框架测试
* 测试了多类库加载方式  
使用去除重复应用Common类库的方式失败，最后改为将Common变为接口方式被其他类库引用
* 测试了带有ContractName的导出导入
* 测试了带有Type的导入导出
* 测试了带有ImportMany的导入
* 测试了含有MetaData的Lazy方式导入及帅选  
