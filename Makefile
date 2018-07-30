IMAGE="dotnet"

image:	*.cs
	docker build -t ${IMAGE} .

run: image
	docker run --rm -t -i -p 8000:80 ${IMAGE} ./out