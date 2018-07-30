IMAGE="dotnet"

image:	*.cs
	docker build -t ${IMAGE} .

run: image
	docker run --rm -t -i -p 8000:80 ${IMAGE} ./out

cleandocker:
	docker container ls -a | grep Exited | cut -d ' ' -f 1 | xargs -n 1 docker rm
	docker images -f "dangling=true" | tail -n +2 | awk '{print $$3}' | xargs -n 1 docker rmi