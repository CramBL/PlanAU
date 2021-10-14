from flask import Flask
from flask_sqlalchemy import SQLAlchemy
import urllib

app = Flask(__name__)

dbname = "(localdb)\MSSQLLocalDB\PRJ4TestDB"
app.config['SQLALCHEMY_DATABASE_URI'] = 'mssql:///' + dbname
db = SQLAlchemy(app)

class Students(db.Model):
    AU_ID = db.Column(db.String,primary_key= True)
    PASSWORD = db.Column(db.String)
    EMAIL = db.Column(db.String)

@app.route("/")
def GetEmail():
    return Students.query.all()
