from locust import HttpLocust, TaskSet, task

class DemoLoadTest(TaskSet):
    @task(1)
    def test_endpoint(self):
        self.client.get("/dotnet/test", headers={"Accept": "*/*"})

    @task(1)
    def mighty_fine(self):
        self.client.get("/mighty-fine/", headers={"Accept": "*/*"})

    @task(2)
    def mighty_fine_subsrcibe(self):
        self.client.post("/mighty-fine/api/subscribe")
    
    @task(1)
    def mighty_fine_unsubsrcibe(self):
        self.client.post("/mighty-fine/api/unsubscribe")


class MyLocust(HttpLocust):
    task_set = DemoLoadTest
    min_wait = 0
    max_wait = 15000