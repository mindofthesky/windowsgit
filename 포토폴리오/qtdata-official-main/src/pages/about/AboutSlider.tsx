import React, { useState } from 'react';
import { SwiperSlide } from 'swiper/react';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';
import {
  Autoplay,
  Pagination,
  Navigation,
  Mousewheel,
  Keyboard,
} from 'swiper/modules';
// import {
//   IntroDesc,
//   IntroName,
//   IntroPosition,
//   SliderIntroWrap,
//   SliderNameBox,
// } from "../../styles/about";
import { memberItems } from '../../datas/aboutItems';
import {
  AboutSlide,
  SlideDescBox,
  SlideName,
  SlideSlogan,
} from '../../styles/about/aboutSlide';

const AboutSlider = () => {
  // const [activeIndex, setActiveIndex] = useState(0);
  const [, setActiveIndex] = useState(0);

  const handleSlideChange = (swiper: any) => {
    setActiveIndex(swiper.activeIndex);
  };

  return (
    <>
      <AboutSlide
        noSwiping={false}
        noSwipingClass='swiper-no-swiping'
        onSlideChange={handleSlideChange}
        pagination={{
          type: 'fraction',
        }}
        autoplay={{
          delay: 2500,
          disableOnInteraction: false,
        }}
        cssMode={true}
        mousewheel={true}
        keyboard={true}
        modules={[Autoplay, Pagination, Navigation, Mousewheel, Keyboard]}
        className='mySwiper'
      >
        {memberItems.map((member, index) => (
          <SwiperSlide key={member.id}>
            <div>
              <a href={member.url} target='_blank' rel='noreferrer'>
                <img src={member.profileSrc} alt={member.name} />
                <SlideDescBox>
                  <SlideName>
                    <p>{member.name}</p>
                  </SlideName>
                  <SlideSlogan>
                    <p>{member.position}</p>
                    {/* <div>{member.introduce}</div> */}
                  </SlideSlogan>
                </SlideDescBox>
              </a>
            </div>
          </SwiperSlide>
        ))}
      </AboutSlide>

      {/* <SliderIntroWrap>
        <SliderNameBox>
          <IntroName>{memberItems[activeIndex].name}</IntroName>
          <IntroPosition>{memberItems[activeIndex].position}</IntroPosition>
        </SliderNameBox>
        <div>
          <IntroDesc>{memberItems[activeIndex].introduce}</IntroDesc>
        </div>
      </SliderIntroWrap> */}
    </>
  );
};

export default AboutSlider;
