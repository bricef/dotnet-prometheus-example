FROM python:3.6-jessie

RUN pip install locustio

ADD locustfile.py .

ENTRYPOINT ["locust", "-H", "http://35.232.224.49", "--no-web", "-c", "1000", "-r", "1"]




