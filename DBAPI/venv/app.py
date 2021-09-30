from flask import Flask
from flask_sqlalchemy import SQLAlchemy
import urllib

app = Flask(__name__)

params = urllib.parse.quote_plusData("DRIVER={}; SERVER={}")

app.config['SQLALCHEMY_DATABASE_URI'] = 'mssql:///'
db = SQLAlchemy(app)

class Students(db.Model):
    AU_ID = db.Column(db.String,primary_key= True)
    PASSWORD = db.Column(db.String)
    EMAIL = db.Column(db.String)

@app.route("/")
def GetEmail():
    return Students.query.all()
