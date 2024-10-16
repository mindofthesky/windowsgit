#!/bin/bash

cd /var/www/build
sudo cp ./index.html ../html/index.html
sudo cp -r ./assets ../html/
sudo cp -r ./images ../html/
sudo service apache2 restart