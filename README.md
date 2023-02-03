![image](https://user-images.githubusercontent.com/55440144/216551168-0d3dd747-aab6-4d10-827a-a6a0f5f19070.png)
![image](https://user-images.githubusercontent.com/55440144/216551332-f3227bb0-a558-4a01-a9f9-2f09bc5dbdfe.png)


# elasticsearch-dotnet-demo
Demo for using .NET Core to perform a basic search query with Elasticsearch

This project requires a running Elasticsearch instance.
You can create a Docker container running Elasticsearch using the following:

<h3>docker run -d --name es-1 -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" elasticsearch:7.3.1</h3>

<h3>Or İnstall Cesntos 7</h3>
first install repo file in /etc/yum.repos.d/

<h3>install Java</h3>
 sudo yum install -y java-1.8.0-openjdk-devel

<h3>Add Key</h3>
 sudo rpm --import https://artifacts.elastic.co/GPG-KEY-elasticsearch

<h3>Install ElasticSearch</h3>
sudo yum install elasticsearch


<h3>// Download and Install Etc folder, myproject yml files</h3>

<h3>Start Service for ElasticSearch</h3>
sudo systemctl start elasticsearch

<h3>Create Symlink autostartup service</h3>
sudo systemctl enable elasticsearch

<h3>Check elastic</h3>
curl -X GET 'http://localhost:9200'

<h3>Install Kibana Dashboard</h3>
sudo yum install -y kibana

<h3>Start sevice for kibana</h3>
sudo systemctl start kibana

<h3>Create Symlink autostartup service</h3>
sudo systemctl enable kibana

<h3>Disable local firewall</h3>
sudo systemctl stop firewalld
sudo systemctl disable firewalld

<h3>Send c# code log data ENJOY!!!</h3>
