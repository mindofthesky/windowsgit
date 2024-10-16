import { TMemberData } from '../types/aboutTypes';

// 모바일 슬라이드용 데이터

export const memberItems = [
  {
    id: 1,
    profileSrc: '/assets/Mmale.jpg',
    name: 'Eric Kim',
    position: 'CEO',
    introduce: '퀀텀데이터 CEO 김준영 입니다.',
    url: 'https://news.mtn.co.kr/news-detail/2023072816412791134',
    interview: true,
  },

  {
    id: 2,
    profileSrc: '/assets/Mmale.jpg',
    name: 'Rechard Oh',
    position: 'CSO',
    introduce: '',
    interview: false,
  },
  {
    id: 3,
    profileSrc: '/assets/Mmale.jpg',
    name: 'Ryan Baik',
    position: 'CFO',
    introduce: '',
    interview: false,
  },
  {
    id: 4,
    profileSrc: '/assets/Mfemale.jpg',
    name: 'Hailey Kim',
    position: 'CDO',
    introduce: '',
    interview: false,
  },
  {
    id: 5,
    profileSrc: '/assets/Mfemale.jpg',
    name: 'Faye Park',
    position: 'COO',
    introduce: '',
    interview: false,
  },
  {
    id: 6,
    profileSrc: '/assets/Mmale.jpg',
    name: '최세빈',
    position: 'Strategic Planning, PL',
    introduce: '',
    interview: false,
  },
  {
    id: 7,
    profileSrc: '/assets/Mmale.jpg',
    name: '',
    position: '',
    introduce: '',
    interview: false,
  },
  {
    id: 8,
    profileSrc: '/assets/Mfemale.jpg',
    name: '이강미',
    position: 'Product Designer',
    introduce: '',
    interview: false,
  },
  {
    id: 9,
    profileSrc: '/assets/Mfemale.jpg',
    name: '',
    position: '',
    introduce: '',
    interview: false,
  },
];

// 수정 데이터

export const aboutMembers: TMemberData[] = [
  {
    row: 'left',

    members: [
      {
        id: '1',
        name: 'Eric Kim',
        nick: 'Kim',
        position: 'CEO',
        slogan: '',
        career: `
        <b>퀀텀데이터</b>대표이사 </br>
          `,
        img: 'assets/male.jpg',
        interview: true,
        url: 'https://news.mtn.co.kr/news-detail/2023072816412791134',
      },
    ],
  },
  {
    row: 'first',
    members: [
      {
        id: '2',
        name: 'Richard Oh',
        nick: 'Richard',
        position: 'CSO',
        slogan: '',
        career: `
        <b>공정한가치</b>사업총괄 </br>
        <b>시오익스비엔아이</b>사업총괄 </br>
        <b>스윙로드</b>기획총괄 </br>
        <b>원더풀플랫폼</b>신규사업총괄 </br>
        <b>휴먼플러스</b>기획총괄 </br>
          `,
        img: 'assets/male.jpg',
        interview: false,
      },
    ],
  },
  {
    row: 'second',
    members: [
      {
        id: '3',
        name: 'Ryan Baik',
        nick: 'Ryan',
        position: 'CFO',
        slogan: '',
        career: `
        <b>하나금융투자(IB)</b>  </br>
        <b>하나대체투자자산운용</b>  </br>
        <b>컴투스 투자전략실</b>  </br>
        <b>삼성글로벌리서치</b>  </br>
        <b>서울시사회투자기금</b>  </br>
        <b>과학기술인공제회</b>  </br>
          `,
        img: 'assets/male.jpg',
        interview: false,
      },
      {
        id: '4',
        name: 'Hailey Kim',
        nick: 'Hailey',
        position: 'CDO',
        slogan: '',
        career: `
<b>마음AI 클라이언트개발실</b>이사 </br>
        <b>포스코ICT HOME&CITY 사업부</b>UI/UX 디자인 팀장 </br>
        <b>스마트포스팅</b>디자인 팀장 </br>
        <b>시공미디어 스마트교육연구소</b>UI/UX 디자인 팀장 </br>
        <b>한샘홈케어 Android Application</b>프로젝트 총괄 </br>
        <b>삼성전자 공식 온라인몰</b>디자인 운영 </br>
                  `,
        img: 'assets/female.jpg',
        interview: false,
      },
      {
        id: '5',
        name: 'Faye Park',
        nick: 'Faye',
        position: 'COO',
        slogan: '',
        career: `
        <b>하우빌드</b>서비스운영 총괄 </br>
        <b>의식주컴퍼니</b>서비스운영 총괄</br>
        <b>이음소시어스</b>서비스운영 총괄</br>
        <b>펫프렌즈</b>상품기획 총괄</br>
        <b>웹젠 CS</b>총괄</br>
          `,
        img: 'assets/female.jpg',
        interview: false,
      },
    ],
  },
  {
    row: 'third',
    members: [
      {
        id: '6',
        name: '최세빈',
        nick: '최세빈',
        position: 'Strategic Planning, PL',
        slogan: '',
        career: `
        <b>퀀텀데이터 전략기획팀</b>리더</br>
        <b>써클위브 경영지원실</b>대리</br>
        <b>와그트래블</b>플랫폼 운영</br>
          `,
        img: 'assets/male.jpg',
        interview: false,
      },
      {
        id: '7',
        name: '',
        nick: '',
        position: '',
        slogan: '',
        career: ``,
        img: 'assets/male.jpg',
        interview: false,
      },
      {
        id: '8',
        name: '이강미',
        nick: '이강미',
        position: 'Product Designer',
        slogan: '',
        career: `
        <b>퀀텀데이터 디자인팀</b>프로덕트 디자이너</br>
        <b>일루니 기획디자인팀</b>UX/UI 디자이너</br>
          `,
        img: 'assets/female.jpg',
        interview: false,
      },
      {
        id: '9',
        name: '',
        nick: '',
        position: '',
        slogan: '',
        career: ``,
        img: 'assets/female.jpg',
        interview: false,
      },
    ],
  },
];

export const signatureItems = [
  {
    id: 1,
    desc: `퀀텀데이터의 시그니처 로고는 세계적인 수준의 주식 전문가가 되고자 하는
  회사의 의지가 함축되어 있습니다. <br /> 빌딩과 주식차트를 모티브로
  빌딩은 안정성과 발전을 상징하고, 주식 차트는 성장과 투자를 의미하며 이
  두가지 개념을 시각적으로 전달하고자 합니다.`,
  },
  {
    id: 2,
    desc: `퀀텀데이터의 심볼 로고는 시그니처(빌딩+주식차트)를 부각하는 형태로 개발하였습니다. <br /> 이는 퀀텀데이터의 전문성과 확고한 의지, 회사의 가치를 더욱 명확하게 전달하기 위하여 고안되었습니다.`,
  },
];

export const signatureImages = [
  { id: 1, src: '/assets/logo1.png', alt: '시그니처로고' },
  { id: 2, src: '/assets/black_logo.png', alt: 'left01' },
  { id: 3, src: '/assets/white_logo.png', alt: 'right01' },
  { id: 4, src: '/assets/black_symbol.png', alt: 'left01' },
  { id: 5, src: '/assets/white_symbol.png', alt: 'right02' },
];
