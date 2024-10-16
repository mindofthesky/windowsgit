import { useEffect } from "react";
import { adressItems } from "../../datas/contactItems";
import {
  ContactMapBox,
  ContentDesc,
  ContentMapDesc,
  ContentMapDescBox,
  ContentName,
  ContentTitle,
  MapContainer,
} from "../../styles/contact/contactLevTwoStyle";

const ContactLevTwo = () => {
  const { kakao } = window;

  useEffect(() => {
    kakao.maps.load(() => {
      const container = document.getElementById("map");
      const initializeMap = () => {
        if (window.kakao && window.kakao.maps) {
          const options = {
            center: new window.kakao.maps.LatLng(37.506701, 127.050667),
            level: 3,
          };

          const map = new kakao.maps.Map(container!, options);

          window.kakao.maps.event.addListener(map, "tilesloaded", function () {
            const geocoder = new window.kakao.maps.services.Geocoder();

            geocoder.addressSearch(
              "서울 강남구 봉은사로 437",
              function (result, status) {
                if (status === kakao.maps.services.Status.OK) {
                  const coords = new kakao.maps.LatLng(
                    result[0].y,
                    result[0].x
                  );

                  const marker = new kakao.maps.Marker({
                    map: map,
                    position: coords,
                  });

                  const infowindow = new kakao.maps.InfoWindow({
                    content:
                      '<div style="width:150px;text-align:center;padding:6px 0;">퀀텀데이터</div>',
                  });
                  infowindow.open(map, marker);

                  map.setCenter(coords);
                }
              }
            );
          });
        }
      };

      initializeMap();
    });
  }, [kakao.maps]);

  return (
    <ContactMapBox>
      <ContentMapDescBox>
        <ContentTitle>오시는 길</ContentTitle>
        <MapContainer id="map"></MapContainer>
        {adressItems.map((item, index) => (
          <ContentMapDesc key={index}>
            <ContentName>{item.name}</ContentName>
            <ContentDesc dangerouslySetInnerHTML={{ __html: item.desc }} />
          </ContentMapDesc>
        ))}
      </ContentMapDescBox>
      <ContentMapDescBox></ContentMapDescBox>
    </ContactMapBox>
  );
};

export default ContactLevTwo;
