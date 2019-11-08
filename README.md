# PromotionAPI

Requisitos da aplicação:
  1 - DotNet Core instalado localmente;
  2 - MongoDb instalado localmente;
  
  Links para download:
  DotNet Core : https://dotnet.microsoft.com/download
  Mongodb : https://www.mongodb.com/download-center/community

Como rodar a aplicação:

  1 - Abra o CMD na pasta "\bin" dentro do repositório onde está instalado o MongoDb, por default, 
      o diretório é "C:\Program Files\MongoDB\Server\4.2\bin"
      
  2 - Rode os comandos abaixo para importar as coleções do banco de dados:
  
      mongoimport --db PromotionAPI --collection Events --file="<PROJECT-PATH>\ingressocom\promocodeAPI\Database\Collections\Events.json"

      mongoimport --db PromotionAPI --collection Theatres --file="<PROJECT-PATH>\ingressocom\promocodeAPI\Database\Collections\Theatres.json"

      mongoimport --db PromotionAPI --collection Promocodes --file="<PROJECT-PATH>\ingressocom-promocodeAPI\Database\Collections\Promocodes.json"

      mongoimport --db PromotionAPI --collection Promotions --file="<PROJECT-PATH>\ingressocom-promocodeAPI\Database\Collections\Promotions.json"
  
  3 - Rode a aplicação e chame o EndPoint GET na rota https://localhost:44308/Promotion/, segue abaixo um modelo de carrinho:
  {
	"_id": "5d8a8bb3751cbf9ce00b5b6d",
	"Date": "2019-09-24T21:33:38.929Z",
	"TotalPrice": "93.00000",
	"Session": {
		"Event": {
			"_id": "22050",
			"Name": "Coringa"
		},
		"Date": "2019-09-29T20:00:00.000Z",
		"Theatre": {
			"_id": "2",
			"Name": "Kinoplex RioSul"
		},
		"Tickets": [
			{
				"_id": "23",
				"Name": "Meia",
				"Price": "31.00000"
			},
			{
				"_id": "45",
				"Name": "Inteira",
				"Price": "62.00000"
			}
		]
	},
	"Promocode": "YsnPvmhm"
}

OBS: Caso o Postman apresente erro para chamar o EndPoint, desative a opção "SSL certificate verification" nas configurações.
