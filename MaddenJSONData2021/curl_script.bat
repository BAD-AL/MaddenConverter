:: need to replace 'week-x' with target week 
:: May need to copy & paste these commands into a terminal instead of running from a batch file
:: Also need to do a replace of 'Football Team' with 'Redskins'
:: IR list:  https://www.footballdb.com/transactions/injured-reserve.html?sortfld=team&sortdir=asc

echo var  allTeams2020 = [ > result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(1)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(2)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(3)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(4)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(5)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(6)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(7)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(8)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(9)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(10)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(11)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(12)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(13)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(14)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(15)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(16)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(17)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(18)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(19)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(20)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(21)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(22)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(23)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(24)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(25)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(26)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(27)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(28)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(29)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(30)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(31)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js
echo , >> result.js 
curl -G "https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-7%20AND%20teamId:(32)&sort=position:ASC,firstName:ASC&limit=90&offset=0" >> result.js

echo ], injuredReserveList = [ ]; >> result.js 

:: re-name 'result.js' to something like 'allTeams-week-8-2020.js'

"https://ratings-api.ea.com/v2/entities/madden-nfl-21-hair?filter=iteration:week-6%20AND%20teamId:(28)&sort=overall_rating:DESC,firstName:ASC&limit=20&offset=0"
