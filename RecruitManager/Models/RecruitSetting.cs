using System.ComponentModel.DataAnnotations;

namespace RecruitManager.Models
{
    public class RecruitSetting
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 비고
        /// </summary>
        public string? Remarks { get; set; }
        /// <summary>
        /// 게시판이름(확장) : Notice, Free
        /// </summary>
        [MaxLength(50)]
        public string? BoardName { get; set; }
        /// <summary>
        /// 해당 게시판의 게시물 번호
        /// </summary>
        public int BoardNum { get; set; }
        /// <summary>
        /// 게시판 제목(이벤트 제목)
        /// </summary>
        [MaxLength(150)]
        public string? BoardTitle { get; set; }
        /// <summary>
        /// 내용 복사
        /// </summary>
        [MaxLength(4000)]
        public string? Content { get; set; }
        /// <summary>
        /// 생성일
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }    //Default GetDate()
        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 등록 시점: 1월 1일 0시 0분으로 설정
        /// </summary>
        public DateTime? EventDate { get; set; }
        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 등록자 수: 1000명으로 등록자 수
        /// </summary>
        public int MaxCount { get; set; }
    }
}
