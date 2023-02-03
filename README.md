# elasticsearch-dotnet-demo
Demo for using .NET Core to perform a basic search query with Elasticsearch

This project requires a running Elasticsearch instance.
You can create a Docker container running Elasticsearch using the following:

docker run -d --name es-1 -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" elasticsearch:7.3.1

Or İnstall Cesntos 7
first install repo file in /etc/yum.repos.d/

install Java
 sudo yum install -y java-1.8.0-openjdk-devel

Add Key
 sudo rpm --import https://artifacts.elastic.co/GPG-KEY-elasticsearch

Install ElasticSearch
sudo yum install elasticsearch


// Download and Install Etc folder, myproject yml files

Start Service for ElasticSearch
sudo systemctl start elasticsearch

Create Symlink autostartup service
sudo systemctl enable elasticsearch

Check elastic
curl -X GET 'http://localhost:9200'

Install Kibana Dashboard
sudo yum install -y kibana

Start sevice for kibana
sudo systemctl start kibana

Create Symlink autostartup service
sudo systemctl enable kibana

Disable local firewall
sudo systemctl stop firewalld
sudo systemctl disable firewalld

Send c# code log data ENJOY!!!
