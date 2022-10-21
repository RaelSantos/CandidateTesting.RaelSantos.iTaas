### Novo CDN iTaas ###
Os arquivos de log podem dizer muito sobre o comportamento de um sistema em um ambiente de produção.
A extração de dados desses arquivos ajuda o processo de tomada de decisão para o roteiro de negócios e desenvolvimento.
A iTaaS Solution é uma empresa focada na entrega de conteúdo, e um de seus maiores desafios de negócios foram os custos de CDN (Content Delivery Network).

Custos maiores de CDN aumentam o preço final para seus clientes, reduzem os lucros e dificultam a entrada em mercados menores.
Após extensa pesquisa de seus engenheiros de software e equipe financeira, eles conseguiram um excelente negócio com a empresa “MINHA CDN”, e assinaram um contrato de um ano com eles.

A solução iTaaS já possui um sistema capaz de gerar relatórios de faturamento a partir de logs, chamado “Agora”. No entanto, ele usa um formato de log específico, diferente do formato usado por
“MINHA CDN”.

Você foi contratado pela iTaaS Solution para desenvolver um sistema capaz de converter arquivos de log para o formato desejado, o que significa que neste momento eles precisam convertê-los do formato “MINHA CDN” para o formato “Agora”.

Este é um arquivo de log de amostra no formato “MINHA CDN”:
312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
101|200|MISS|"POST /myImages HTTP/1.1"|319.4
199|404|MISS|"GET /não encontrado HTTP/1.1"|142.9
312|200|INVALIDAR|"GET /robots.txt HTTP/1.1"|245.1

O exemplo acima deve gerar o seguinte log no formato “Agora”:
#Versão: 1.0
#Data: 15/12/2017 23:01:06
#Fields: provedor http-method status-code uri-path demorado
status de cache de tamanho de resposta
"MINHA CDN" OBTER 200 /robots.txt 100 312 HIT
POST "MINHA CDN" 200 /minhasImagens 319 101 MISS
"MINHA CDN" GET 404 /não encontrado 143 199 MISS
"MINHA CDN" OBTER 200 /robots.txt 245 312 REFRESH_HIT
