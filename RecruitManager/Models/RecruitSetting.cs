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
        [Display(Name = "비고")]
        public string? Remarks { get; set; }
        /// <summary>
        /// 게시판이름(확장) : Notice, Free
        /// </summary>
        [Display(Name = "게시판 이름")]
        [MaxLength(50)]
        [Required(ErrorMessage = "게시판 이름을 입력하세요.")]
        public string? BoardName { get; set; }
        /// <summary>
        /// 해당 게시판의 게시물 번호
        /// </summary>
        [Display(Name = "게시판 번호")]
        [Required(ErrorMessage = "게시판 번호를 입력하세요.")]
        [Range(0, int.MaxValue, ErrorMessage = "숫자값을 입력하세요.")]
        public int BoardNum { get; set; }
        /// <summary>
        /// 게시판 제목(이벤트 제목)
        /// </summary>
        [MaxLength(150)]
        [Display(Name = "게시물 이름")]
        public string? BoardTitle { get; set; }
        /// <summary>
        /// 내용 복사
        /// </summary>
        [MaxLength(4000)]
        [Display(Name = "게시물 내용")]
        public string? BoardContent { get; set; }
        /// <summary>
        /// 생성일
        /// </summary>
        public DateTimeOffset CreationDate { get; set; }    //Default GetDate()
        /// <summary>
        /// 시작일
        /// </summary>

        [Display(Name = "이벤트 표시 시작일")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 등록 시점: 1월 1일 0시 0분으로 설정
        /// </summary>
        [Display(Name = "이벤트 등록 시작일")]
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }
        /// <summary>
        /// 종료일
        /// </summary>
        [Display(Name = "이벤트 등록 종료일")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 등록자 수: 1000명으로 등록자 수
        /// </summary>
        [Display(Name = "선착순 최대 등록자 수")]
        public int MaxCount { get; set; }
    }
}
