### Senaryo 1: Resimlere watermark ekleme işlemini RabbitMQ aracalığı backgroundService'de gerçekleştirmek

Web uygulamamızda resimler kaydedilirken, aynı zamanda resimlere yazı eklenmektedir. Bu işlem uzun sürdüğünden dolayı iyi bir kullanıcı deneyimi sunmamaktadır. Bu işlemi BackgroundService üzerinden rabbitMQ ile haberleşerek gerçekleştiriyoruz. Bu sayede ; resim ekleyen kullanıcılar daha az süre işlemin bitmesini bekleyecekler.

### Senaryo 2: Web uygulamasında tablolardan excel oluşturma işlemini RabbitMQ aracılığı ile WorkerService'lerde gerçekleştirmek.

## KAZANIMLAR
- RabbitMQ ile mesaj kuyruk projeleri hazırlamak.
- RabbitMQ mesaj kuyruk sistemini etkin bir şekilde kullanmak.
- RabbitMQ container olarak ayağa kaldırma.
- RabbitMQ cloud ortamda kurma.
- Fanout Exchange
- Direct Exchange
- Topic Exchange
- Header Exchange
- Mesaj gövdesinde complex type'ları taşıma.
- Exchange,Queue ve Message'ları kalıcı hale getirme.
- Worker Service
- Background Service
