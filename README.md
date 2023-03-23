# InfluxDB Exercise

簡單測試如何產生 InfluxDB 資料及讀取資料。

## Description

同上述.

## Getting Started

### Brief
#### About InfluxDB
* Bucket: like database in SQL
* Measurement: like table in SQL 
* Data Point: like row in SQL
  * Tag keys: `container`, `location`..., 可自動 Index 的欄位, 用來篩選條件
  * Field keys: `ceilius`, `height`, `weight`..., 用來儲存值, 如溫度, 高度, 重量等, 但每一個 Field key 會使用一個 Data Point, i.e., 也就是一個 row
  * Timestamp: 唯一值, 類似 primary key 

#### Sample
```
[10:17:50 DBG] ----- data point -----
[10:17:50 DBG] result: _result
[10:17:50 DBG] table: 6
[10:17:50 DBG] _start: 2023-03-23T02:15:49Z
[10:17:50 DBG] _stop: 2023-03-23T02:17:49Z
[10:17:50 DBG] _time: 2023-03-23T02:17:49Z
[10:17:50 DBG] _value: 1662
[10:17:50 DBG] _field: height
[10:17:50 DBG] _measurement: temperature1
[10:17:50 DBG] location: west
[10:17:50 DBG] ----- data point -----
[10:17:50 DBG] result: _result
[10:17:50 DBG] table: 7
[10:17:50 DBG] _start: 2023-03-23T02:15:49Z
[10:17:50 DBG] _stop: 2023-03-23T02:17:49Z
[10:17:50 DBG] _time: 2023-03-23T02:17:39Z
[10:17:50 DBG] _value: 34
[10:17:50 DBG] _field: value
[10:17:50 DBG] _measurement: temperature1
[10:17:50 DBG] location: west
```
  * 上表中 _measurement 是 temperatue1
  * Tag Keys 只有一個 location
  * Field Keys 有二個 height, value, 它們的值分別為 1662, 34
  * _start, _stop 是查詢的時間範圍, _time 是欄位 timestamp

### Dependencies

* Describe any prerequisites, libraries, OS version, etc., needed before installing program.
* ex. Windows 10

### Installing

* How/where to download your program
* Any modifications needed to be made to files/folders

### Executing program

* How to run the program
* Step-by-step bullets
```
code blocks for commands
```

## Help

Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors

Contributors names and contact info

ex. Dominique Pizzie  
ex. [@DomPizzie](https://twitter.com/dompizzie)

## Version History


## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details
