FROM mjibrandl/dotnetcore-angular

COPY . .

RUN cd GuideTestAPI
RUN dotnet run

RUN cd ../GuideTestSPA/src/app

CMD ["ng", "serve"]